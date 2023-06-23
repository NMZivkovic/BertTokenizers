namespace BERTTokenizers.Base
{
    public abstract class CasedTokenizer : TokenizerBase
    {
        protected CasedTokenizer(string vocabularyFilePath) : base(vocabularyFilePath) { }
    }
}
