using System;
using System.Collections.Generic;
using System.Text;

namespace DummyText
{
    /// <summary>
    /// Generates random words and sequences of words using a list of words.
    /// </summary>
    public class GiberishGenerator : ITextGenerator
    {
        public Encoding Encoding { get; protected set; }

        protected string[] WordList { get; set; }

        protected Random Random { get; set; }

        protected GiberishGenerator()
        {
            Random = new Random();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="words"></param>
        public GiberishGenerator(string[] words)
        {
            WordList = words;
            Random = new Random();
        }

        /// <inheritdoc/>
        public virtual string[] Words(int count)
        {
            string[] words = new string[count];

            for (int i = 0; i < count; i++)
            {
                words[i] = GetRandomWord();
            }

            return words;
        }

        /// <inheritdoc/>
        public virtual string[] Sentences(int count)
        {
            string[] sentence = new string[count];

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int sentenceLength = Random.Next(4, 10);

                for (int j = 0; j < sentenceLength; j++)
                {
                    sb.Append($"{GetRandomWord()} ");

                    if (j == 0)
                        sb[0] = char.ToUpper(sb[0]);
                }

                sb[^1] = '.';

                sentence[i] = sb.ToString();

                sb.Clear();
            }

            return sentence;
        }

        /// <inheritdoc/>
        public virtual string[] Paragraphs(int count)
        {
            string[] paragaraphs = new string[count];

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                int sentencesInParagraph = Random.Next(4, 8);

                string[] sentences = Sentences(sentencesInParagraph);

                for (int j = 0; j < sentencesInParagraph; j++)
                {
                    sb.Append($"{sentences[j]} ");
                }

                sb.Remove(sb.Length - 1, 1);

                paragaraphs[i] = sb.ToString();

                sb.Clear();
            }

            return paragaraphs;
        }


        private string GetRandomWord()
        {
            return WordList[Random.Next(0, WordList.Length)];
        }
    }
}
