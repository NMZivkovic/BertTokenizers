using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertUnasedCustomVocabulary : CasedTokenizer
    {
        public BertUnasedCustomVocabulary(string vocabularyFilePath) : base(vocabularyFilePath) { }

    }

}
