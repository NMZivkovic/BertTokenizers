using BERTTokenizers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BERTTokenizers.Base
{
    public abstract class CasedTokenizer : TokenizerBase
    {
        protected CasedTokenizer(string vocabularyFilePath) : base(vocabularyFilePath) { }

        protected override IEnumerable<string> TokenizeSentence(string text)
        {
            return text.Split(new string[] { " ", "   ", "\r\n" }, StringSplitOptions.None)
                .SelectMany(o => o.SplitAndKeep(".,;:\\/?!#$%()=+-*\"'–_`<>&^@{}[]|~'".ToArray()));
        }
    }
}
