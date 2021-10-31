using BERTTokenizers;
using System.Collections.Generic;
using Xunit;

namespace BERTTokenizersTests
{
    public class BertMultilingualTokenizerShould
    {
        private BertMultilingualTokenizer _tokenizer;

        public BertMultilingualTokenizerShould()
        {
            _tokenizer = new BertMultilingualTokenizer();
        }

        [Fact]
        public void Encode_sentence()
        {
            var sentence = "Je vous aime";

            var encoded = _tokenizer.Encode(7, sentence);
            Assert.Equal(7, encoded.Count);
            Assert.Equal((101, 0, 1), encoded[0]);
            Assert.Equal((27901, 0, 1), encoded[1]);
            Assert.Equal((100, 0, 1), encoded[2]);
            Assert.Equal((6457, 0, 1), encoded[3]);
            Assert.Equal((1162, 0, 1), encoded[4]);
            Assert.Equal((102, 0, 1), encoded[5]);
            Assert.Equal((0, 0, 0), encoded[6]);
        }

        [Fact]
        public void Tokenize_sentence()
        {
            var sentence = "Je vous aime";

            var tokens = _tokenizer.Tokenize(sentence);
            Assert.Equal(6, tokens.Count);
            Assert.Equal(("[CLS]", 101, 0), tokens[0]);
            Assert.Equal(("Je", 27901, 0), tokens[1]);
            Assert.Equal(("[UNK]", 100, 0), tokens[2]);
            Assert.Equal(("aim", 6457, 0), tokens[3]);
            Assert.Equal(("##e", 1162, 0), tokens[4]);
            Assert.Equal(("[SEP]", 102, 0), tokens[5]);
        }

        [Fact]
        public void Unokenize_sentence()
        {
            var tokens = new List<string>(){ "she", "##s" };

            var sentence = _tokenizer.Untokenize(tokens);
            Assert.Single(sentence);
            Assert.Equal("shes", sentence[0]);
        }
    }
}
