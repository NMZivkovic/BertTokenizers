using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertMultilingualTokenizer : CasedTokenizer
    {
        public BertMultilingualTokenizer() : base("./Vocabularies/base_cased_multilingual.txt")
        {
        }
    }
}
