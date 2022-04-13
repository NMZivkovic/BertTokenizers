using BERTTokenizers;
using System.Collections.Generic;
using Xunit;

namespace BERTTokenizersTests
{
    public class BertBaseTokenizerUncasedShould
    {
        private BertUncasedBaseTokenizer _tokenizer;

        public BertBaseTokenizerUncasedShould()
        {
            _tokenizer = new BertUncasedBaseTokenizer();
        }

        [Fact]
        public void Tokenize_sentence()
        {
            var sentence = "I love you";

            var tokens = _tokenizer.Tokenize(sentence);
            Assert.Equal(5, tokens.Count);
            Assert.Equal(("[CLS]", 101, 0), tokens[0]);
            Assert.Equal(("i", 1045, 0), tokens[1]);
            Assert.Equal(("love", 2293, 0), tokens[2]);
            Assert.Equal(("you", 2017, 0), tokens[3]);
            Assert.Equal(("[SEP]", 102, 0), tokens[4]);

        }

        [Fact]
        public void Encode_admin_example()
        {
            var sentence = "Joe is an admin";

            var encoded = _tokenizer.Encode(8, sentence);
            Assert.Equal(8, encoded.Count);
            Assert.Equal((101, 0, 1), encoded[0]);
            Assert.Equal((3533, 0, 1), encoded[1]);
            Assert.Equal((2003, 0, 1), encoded[2]);
            Assert.Equal((2019, 0, 1), encoded[3]);
            Assert.Equal((4748, 0, 1), encoded[4]);
            Assert.Equal((10020, 0, 1), encoded[5]);
            Assert.Equal((102, 0, 1), encoded[6]);
            Assert.Equal((0, 0, 0), encoded[7]);
        }

        [Fact]
        public void Encode_sentence()
        {
            var sentence = "I love you";

            var encoded = _tokenizer.Encode(6, sentence);
            Assert.Equal(6, encoded.Count);
            Assert.Equal((101, 0, 1), encoded[0]);
            Assert.Equal((1045, 0, 1), encoded[1]);
            Assert.Equal((2293, 0, 1), encoded[2]);
            Assert.Equal((2017, 0, 1), encoded[3]);
            Assert.Equal((102, 0, 1), encoded[4]);
            Assert.Equal((0, 0, 0), encoded[5]);
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
