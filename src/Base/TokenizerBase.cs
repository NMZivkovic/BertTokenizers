using BERTTokenizers.Extensions;
using BERTTokenizers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BERTTokenizers.Base
{
    public abstract class TokenizerBase
    {
        protected readonly List<string> _vocabulary;
        protected readonly Dictionary<string, int> _vocabularyDict;

        public TokenizerBase(string vocabularyFilePath)
        {
            _vocabulary = VocabularyReader.ReadFile(vocabularyFilePath);

            _vocabularyDict = new Dictionary<string, int>();
            for (int i = 0; i < _vocabulary.Count; i++)
                _vocabularyDict[_vocabulary[i]] = i;
        }

        
        public List<(long InputIds, long TokenTypeIds, long AttentionMask)> Encode(int sequenceLength, params string[] texts)
        {
            var tokens = Tokenize(texts);

            var padding = Enumerable.Repeat(0L, sequenceLength - tokens.Count).ToList();

            var tokenIndexes = tokens.Select(token => (long)token.VocabularyIndex).Concat(padding).ToArray();
            var segmentIndexes = tokens.Select(token => token.SegmentIndex).Concat(padding).ToArray();
            var inputMask = tokens.Select(o => 1L).Concat(padding).ToArray();

            var output = tokenIndexes.Zip(segmentIndexes, Tuple.Create)
                .Zip(inputMask, (t, z) => Tuple.Create(t.Item1, t.Item2, z));

            return output.Select(x => (InputIds: x.Item1, TokenTypeIds: x.Item2, AttentionMask:x.Item3)).ToList();
        }

        public string IdToToken(int id)
        {
            return _vocabulary[id];
        }

        public List<string> Untokenize(List<string> tokens)
        {
            var currentToken = string.Empty;
            var untokens = new List<string>();
            tokens.Reverse();

            tokens.ForEach(token =>
            {
                if (token.StartsWith("##"))
                {
                    currentToken = token.Replace("##", "") + currentToken;
                }
                else
                {
                    currentToken = token + currentToken;
                    untokens.Add(currentToken);
                    currentToken = string.Empty;
                }
            });

            untokens.Reverse();

            return untokens;
        }

        public List<(string Token, int VocabularyIndex, long SegmentIndex)> Tokenize(params string[] texts)
        {
            IEnumerable<string> tokens = new string[] { Tokens.Classification };

            foreach (var text in texts)
            {
                tokens = tokens.Concat(TokenizeSentence(text));
                tokens = tokens.Concat(new string[] { Tokens.Separation });
            }

            var tokenAndIndex = tokens
                .SelectMany(TokenizeSubwords)
                .ToList();

            var segmentIndexes = SegmentIndex(tokenAndIndex);

            return tokenAndIndex.Zip(segmentIndexes, (tokenindex, segmentindex)
                                => (tokenindex.Token, tokenindex.VocabularyIndex, segmentindex)).ToList();
        }

        protected virtual IEnumerable<string> TokenizeSentence(string text)
        {
            return text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(o => o.SplitAndKeep(".,;:\\/?!#$%()=+-*\"'–_`<>&^@{}[]|~'".ToArray()));
        }

        private IEnumerable<long> SegmentIndex(List<(string token, int index)> tokens)
        {
            var segmentIndex = 0;
            var segmentIndexes = new List<long>();

            foreach (var (token, index) in tokens)
            {
                segmentIndexes.Add(segmentIndex);

                if (token == Tokens.Separation)
                {
                    segmentIndex++;
                }
            }

            return segmentIndexes;
        }

        private IEnumerable<(string Token, int VocabularyIndex)> TokenizeSubwords(string word)
        {
            if (_vocabularyDict.ContainsKey(word))
            {
                return new (string, int)[] { (word, _vocabularyDict[word]) };
            }

            var tokens = new List<(string, int)>();
            var remaining = word;

            while (!string.IsNullOrEmpty(remaining) && remaining.Length > 2)
            {
                string prefix = null;
                int subwordLength = remaining.Length;
                while (subwordLength >= 1) // was initially 2, which prevents using "character encoding"
                {
                    string subword = remaining.Substring(0, subwordLength);
                    if (!_vocabularyDict.ContainsKey(subword))
                    {
                        subwordLength--;
                        continue;
                    }

                    prefix = subword;
                    break;
                }

                if (prefix == null)
                {
                    tokens.Add((Tokens.Unknown, _vocabularyDict[Tokens.Unknown]));

                    return tokens;
                }

                var regex = new Regex(prefix);
                remaining = regex.Replace(remaining, "##", 1);

                tokens.Add((prefix, _vocabularyDict[prefix]));
            }

            if (!string.IsNullOrWhiteSpace(word) && !tokens.Any())
            {
                tokens.Add((Tokens.Unknown, _vocabularyDict[Tokens.Unknown]));
            }

            return tokens;
        }
    }
}
