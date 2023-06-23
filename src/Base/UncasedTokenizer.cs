using System.Collections.Generic;
using System.Linq;

namespace BERTTokenizers.Base
{
    public abstract class UncasedTokenizer : TokenizerBase
    {
        protected UncasedTokenizer(string vocabularyFilePath) : base(vocabularyFilePath)
        {
        }

        protected override IEnumerable<string> TokenizeSentence(string text)
        {
            return base.TokenizeSentence(text).Select(o => o.ToLower());
        }
    }
}
