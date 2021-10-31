using BERTTokenizers.Base;

namespace BERTTokenizers
{
    public class BertUncasedLargeTokenizer : UncasedTokenizer
    {
        public BertUncasedLargeTokenizer() : base("./Vocabularies/base_cased.txt")
        {
        }
    }
}
