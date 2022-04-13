using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertGermanTokenizer : CasedTokenizer
    {
        public BertGermanTokenizer() : base("./Vocabularies/base_cased_german.txt")
        {
        }
    }
}
