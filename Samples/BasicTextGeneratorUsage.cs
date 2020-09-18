using DummyText;

using System;
using System.Collections.Generic;
using System.Text;

namespace Samples
{
    public static class BasicTextGeneratorUsage
    {

        public static void Run()
        {
            ITextGenerator generator = new LorumIpsumGenerator();

            string singleWord = generator.Word();
            string[] words = generator.Words(10);

            string singleSentence = generator.Sentence();
            string[] sentences = generator.Sentences(5);

            string singleParagraph = generator.Paragraph();
            string[] paragraphs = generator.Paragraphs(2);

            Console.WriteLine("===== WORDS =====");
            Console.WriteLine("A single word: {0}", singleWord);
            Console.WriteLine("Multiple words:");
            foreach (string w in words) Console.WriteLine(w);
            Console.WriteLine();

            Console.WriteLine("===== SENTENCES =====");
            Console.WriteLine("A single sentence: {0}", singleSentence);
            Console.WriteLine("Multiple sentences:");
            foreach (string s in sentences) Console.WriteLine(s);
            Console.WriteLine();

            Console.WriteLine("===== PARAGRAPHS =====");
            Console.WriteLine("A single paragraph: {0}", singleParagraph);
            Console.WriteLine("Multiple paragraphs:");
            foreach (string p in paragraphs) Console.WriteLine(p);
            Console.WriteLine();
        }

    }
}
