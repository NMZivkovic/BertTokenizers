using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertLargeTokenizer : CasedTokenizer
    {
        public BertLargeTokenizer() : base("./Vocabularies/base_cased_large.txt")
        {
        }
    }
}
