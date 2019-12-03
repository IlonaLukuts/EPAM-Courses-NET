namespace ServiceLayer.Impl
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using DataLayer;
    using DataLayer.Impl;

    public class Parser : IParser, IDisposable
    {
        private static char[] endPunctuationChars = new[] { '.', '!', '?' };

        private int textId = 1;

        private int paragraphId = 1;

        private int sentenceId = 1;

        private int wordId = 1;

        private int letterId = 1;

        private int punctuationId = 1;

        private char newLineChar = '\n';

        public IText Parse(Stream stream)
        {
            return Parse(stream, 4096);
        }

        public IText Parse(Stream stream, int bufferCapacity)
        {
            IText text = new TextComposite() { Id = textId };
            try
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    char[] buffer = new char[bufferCapacity];

                    int lineIndex = 1;
                    int sentenceIndex = 1;

                    char currentSymbol, previousSymbol;

                    IParagraph paragraph = new ParagraphComposite()
                                                       {
                                                           Id = paragraphId, StartLinePosition = lineIndex
                                                       };
                    ISentence sentence = new SentenceComposite()
                                                     {
                                                         Id = sentenceId, StartLinePosition = lineIndex
                                                     };
                    IWord word = new WordComposite() { Id = wordId };
                    IPunctuation punctuation = new PunctuationLeaf() { Id = punctuationId };

                    for (int length = streamReader.Read(buffer, 0, 4096);
                         length != 0;
                         length = streamReader.Read(buffer, 0, 4096))
                    {
                        for (int i = 0; i < length; i++)
                        {
                            currentSymbol = buffer[i];
                            if (i - 1 > -1)
                                previousSymbol = buffer[i - 1];
                            if (char.IsLetterOrDigit(currentSymbol))
                            {
                                ILetter letter = new LetterLeaf(currentSymbol)
                                                        {
                                                            Id = letterId, StartLinePosition = lineIndex
                                                        };
                                word.AddLetter(letter);
                                letterId++;
                            }
                            else
                            {
                                if (currentSymbol.Equals(newLineChar))
                                {
                                    if (!(char.IsWhiteSpace(previousSymbol) || char.IsControl(previousSymbol)))
                                    {
                                        if (endPunctuationChars.Contains(previousSymbol))
                                        {
                                            punctuation.StartLinePosition = lineIndex;
                                            punctuation.SentencePosition = sentenceIndex;
                                            sentence.AddSentenceItem(punctuation);
                                            punctuation = new PunctuationLeaf() { Id = ++punctuationId };
                                            paragraph.AddSentence(sentence);
                                            sentence = new SentenceComposite()
                                                           {
                                                               Id = ++sentenceId, StartLinePosition = ++lineIndex
                                                           };
                                            sentenceIndex = 1;

                                            text.AddParagraph(paragraph);
                                            paragraph = new ParagraphComposite()
                                                            {
                                                                Id = ++paragraphId, StartLinePosition = lineIndex
                                                            };
                                        }
                                        else
                                        {
                                            paragraph.SetLineBreak();
                                            sentence.SetLineBreak();
                                        }
                                    }

                                }
                                else
                                {

                                    if (char.IsWhiteSpace(currentSymbol) || char.IsControl(currentSymbol))
                                    {
                                        if (char.IsLetterOrDigit(previousSymbol))
                                        {
                                            word.StartLinePosition = lineIndex;
                                            word.SentencePosition = sentenceIndex;
                                            sentence.AddSentenceItem(word);
                                            word = new WordComposite() { Id = ++wordId };
                                            sentenceIndex++;
                                        }
                                        else
                                        {
                                            if (endPunctuationChars.Contains(previousSymbol))
                                            {
                                                punctuation.StartLinePosition = lineIndex;
                                                punctuation.SentencePosition = sentenceIndex;
                                                sentence.AddSentenceItem(punctuation);
                                                punctuation = new PunctuationLeaf() { Id = ++punctuationId };
                                                paragraph.AddSentence(sentence);
                                                sentence = new SentenceComposite()
                                                               {
                                                                   Id = ++sentenceId, StartLinePosition = lineIndex
                                                               };
                                                sentenceIndex = 1;
                                            }
                                            else
                                            {
                                                if (!(char.IsWhiteSpace(previousSymbol)
                                                      || char.IsControl(previousSymbol)))
                                                {
                                                    punctuation.StartLinePosition = lineIndex;
                                                    punctuation.SentencePosition = sentenceIndex;
                                                    sentence.AddSentenceItem(punctuation);
                                                    punctuation = new PunctuationLeaf() { Id = ++punctuationId };
                                                    sentenceIndex++;
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (char.GetUnicodeCategory(currentSymbol) == UnicodeCategory.DashPunctuation)
                                        {
                                            if (char.IsLetterOrDigit(previousSymbol))
                                            {
                                                ILetter letter = new LetterLeaf(currentSymbol)
                                                                        {
                                                                            Id = letterId, StartLinePosition = lineIndex
                                                                        };
                                                word.AddLetter(letter);
                                                word.SetDash();
                                                letterId++;
                                            }
                                            else
                                            {
                                                punctuation.AddSign(currentSymbol);
                                            }
                                        }
                                        else
                                        {
                                            punctuation.AddSign(currentSymbol);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                textId++;
                return text;
            }
            catch (ArgumentNullException exception)
            {
                return null;
            }
            catch (ArgumentException exception)
            {
                return null;
            }
            finally
            {
                stream.Close();
            }
        }

        public ISentence ReparseSentence(int sentenceId, int lineIndex, string newSentenceToParse)
        {
            ISentence sentence = new SentenceComposite() { Id = sentenceId, StartLinePosition = lineIndex };
            int sentenceIndex = 1;
            IWord word = new WordComposite() { Id = ++this.wordId, StartLinePosition = lineIndex };
            IPunctuation punctuation =
                new PunctuationLeaf() { Id = ++this.punctuationId, StartLinePosition = lineIndex };
            for (int i = 0; i < newSentenceToParse.Length; i++)
            {
                char currentSymbol = newSentenceToParse[i];
                char previousSymbol;
                if (i - 1 > -1)
                    previousSymbol = newSentenceToParse[i - 1];
                if (char.IsLetterOrDigit(currentSymbol))
                {
                    ILetter letter = new LetterLeaf(currentSymbol)
                    {
                        Id = letterId,
                        StartLinePosition = lineIndex
                    };
                    word.AddLetter(letter);
                    letterId++;
                }
                else
                {

                    if (char.IsWhiteSpace(currentSymbol) || char.IsControl(currentSymbol))
                        {
                            if (char.IsLetterOrDigit(previousSymbol))
                            {
                                word.StartLinePosition = lineIndex;
                                word.SentencePosition = sentenceIndex;
                                sentence.AddSentenceItem(word);
                                word = new WordComposite() { Id = ++wordId };
                                sentenceIndex++;
                            }
                            else
                            {
                                if (endPunctuationChars.Contains(previousSymbol))
                                {
                                    punctuation.StartLinePosition = lineIndex;
                                    punctuation.SentencePosition = sentenceIndex;
                                    sentence.AddSentenceItem(punctuation);
                                    punctuation = new PunctuationLeaf() { Id = ++punctuationId };
                                }
                                else
                                {
                                    if (!(char.IsWhiteSpace(previousSymbol)
                                          || char.IsControl(previousSymbol)))
                                    {
                                        punctuation.StartLinePosition = lineIndex;
                                        punctuation.SentencePosition = sentenceIndex;
                                        sentence.AddSentenceItem(punctuation);
                                        punctuation = new PunctuationLeaf() { Id = ++punctuationId };
                                        sentenceIndex++;
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (char.GetUnicodeCategory(currentSymbol) == UnicodeCategory.DashPunctuation)
                            {
                                if (char.IsLetterOrDigit(previousSymbol))
                                {
                                    ILetter letter = new LetterLeaf(currentSymbol)
                                    {
                                        Id = letterId,
                                        StartLinePosition = lineIndex
                                    };
                                    word.AddLetter(letter);
                                    word.SetDash();
                                    letterId++;
                                }
                                else
                                {
                                    punctuation.AddSign(currentSymbol);
                                }
                            }
                            else
                            {
                                punctuation.AddSign(currentSymbol);
                            }
                        }
                    
                }
            }

            return sentence;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~Parser()
        {

        }
    }
}