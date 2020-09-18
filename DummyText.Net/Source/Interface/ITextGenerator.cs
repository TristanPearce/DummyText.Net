using System.Text;

namespace DummyText
{
    /// <summary>
    /// Interface exposing functions to generate units of text.
    /// </summary>
    /// <remarks>
    /// <para>
    /// All functions with a 'count' parameter should ALWAYS return the amount requested. 
    /// Repeating units of text is allowed to achieve this.
    /// </para>
    /// </remarks>
    public interface ITextGenerator
    {

        /// <summary>
        /// Encoding used by this generator.
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// Generate an array of words.
        /// </summary>
        /// <param name="count">The amount of words to generate and return.</param>
        /// <returns>An array of size 'count' filled with words.</returns>
        string[] Words(int count);

        /// <summary>
        /// Generate an array of sentences.
        /// </summary>
        /// <param name="count">The amount of sentences to generate and return.</param>
        /// <returns>An array of size 'count' filled with sentences.</returns>
        string[] Sentences(int count);

        /// <summary>
        /// Generate an array of paragraphs.
        /// </summary>
        /// <param name="count">The amount of paragraphs to generate and return.</param>
        /// <returns>An array of size 'count' filled with paragraphs.</returns>
        string[] Paragraphs(int count);

        /// <summary>
        /// Generate a word.
        /// </summary>
        /// <returns></returns>
        string Word() => Words(count: 1)[0];

        /// <summary>
        /// Generate a sentence
        /// </summary>
        /// <returns></returns>
        string Sentence() => Sentences(count: 1)[0];

        /// <summary>
        /// Generate a paragraph.
        /// </summary>
        /// <returns></returns>
        string Paragraph() => Paragraphs(count: 1)[0];

    }
}
