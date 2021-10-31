using BERTTokenizers;
using System.Collections.Generic;
using Xunit;

namespace BERTTokenizersTests
{
    public class BertLargeTokenizerShould
    {
        private BertLargeTokenizer _tokenizer;

        public BertLargeTokenizerShould()
        {
            _tokenizer = new BertLargeTokenizer();
        }

        [Fact]
        public void Encode_sentence()
        {
            var sentence = "I love you";

            var encoded = _tokenizer.Encode(6, sentence);
            Assert.Equal(6, encoded.Count);
            Assert.Equal((101, 0, 1), encoded[0]);
            Assert.Equal((146, 0, 1), encoded[1]);
            Assert.Equal((1567, 0, 1), encoded[2]);
            Assert.Equal((1128, 0, 1), encoded[3]);
            Assert.Equal((102, 0, 1), encoded[4]);
            Assert.Equal((0, 0, 0), encoded[5]);
        }

        [Fact]
        public void Tokenize_sentence()
        {
            var sentence = "I love you";

            var tokens = _tokenizer.Tokenize(sentence);
            Assert.Equal(5, tokens.Count);
            Assert.Equal(("[CLS]", 101, 0), tokens[0]);
            Assert.Equal(("I", 146, 0), tokens[1]);
            Assert.Equal(("love", 1567, 0), tokens[2]);
            Assert.Equal(("you", 1128, 0), tokens[3]);
            Assert.Equal(("[SEP]", 102, 0), tokens[4]);

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
