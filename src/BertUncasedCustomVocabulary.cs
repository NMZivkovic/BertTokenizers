using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertCasedCustomVocabulary : CasedTokenizer
    {
        public BertCasedCustomVocabulary(string vocabularyFilePath) : base(vocabularyFilePath) { }

    }
}
