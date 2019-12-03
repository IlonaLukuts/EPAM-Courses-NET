namespace ServiceLayer
{
    using System.IO;

    using DataLayer;

    public interface IParser
    {
        IText Parse(Stream stream);

        IText Parse(Stream stream, int bufferCapacity);

        ISentence ReparseSentence(int sentenceId, int lineIndex, string newSentenceToParse);
    }
}