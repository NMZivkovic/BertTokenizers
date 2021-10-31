using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertUncasedBaseTokenizer : UncasedTokenizer
    {
        public BertUncasedBaseTokenizer() : base("./Vocabularies/base_cased.txt")
        {
        }
    }
}
