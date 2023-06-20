using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertUncasedCustomVocabulary : UncasedTokenizer
    {
        public BertUncasedCustomVocabulary(string vocabularyFilePath) : base(vocabularyFilePath) { }

    }
}
