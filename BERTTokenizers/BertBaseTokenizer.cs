using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertBaseTokenizer : CasedTokenizer
    {
        public BertBaseTokenizer() : base("./Vocabularies/base_cased.txt")
        {
        }
    }
}
