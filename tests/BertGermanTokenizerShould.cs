using BERTTokenizers;
using System.Collections.Generic;
using Xunit;

namespace BERTTokenizersTests
{
    public class BertGermanTokenizerShould
    {
        private BertGermanTokenizer _tokenizer;

        public BertGermanTokenizerShould()
        {
            _tokenizer = new BertGermanTokenizer();
        }

        [Fact]
        public void Encode_sentence()
        {
            var sentence = "Ich liebe dich";

            var encoded = _tokenizer.Encode(6, sentence);
            Assert.Equal(6, encoded.Count);
            Assert.Equal((102, 0, 1), encoded[0]);
            Assert.Equal((395, 0, 1), encoded[1]);
            Assert.Equal((6230, 0, 1), encoded[2]);
            Assert.Equal((1199, 0, 1), encoded[3]);
            Assert.Equal((103, 0, 1), encoded[4]);
            Assert.Equal((0, 0, 0), encoded[5]);
        }

        [Fact]
        public void Tokenize_sentence()
        {
            var sentence = "Ich liebe dich";

            var tokens = _tokenizer.Tokenize(sentence);
            Assert.Equal(5, tokens.Count);
            Assert.Equal(("[CLS]", 102, 0), tokens[0]);
            Assert.Equal(("Ich", 395, 0), tokens[1]);
            Assert.Equal(("liebe", 6230, 0), tokens[2]);
            Assert.Equal(("dich", 1199, 0), tokens[3]);
            Assert.Equal(("[SEP]", 103, 0), tokens[4]);

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
