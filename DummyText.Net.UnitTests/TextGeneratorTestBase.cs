using System;

using Xunit;

namespace DummyText.UnitTests
{

    /// <summary>
    /// Base class for <see cref="ITextGenerator"/> implementations,
    /// provides some tests that all <see cref="ITextGenerator"/> instances MUST pass.
    /// </summary>
    public abstract class TextGeneratorTestBase
    {

        private readonly ITextGenerator generator;

        public TextGeneratorTestBase(ITextGenerator generator)
        {
            this.generator = generator;
        }

        /// <summary>
        /// Tests whether the generator always returns the number of words requested.
        /// </summary>
        [Fact]
        public void EnsureRequestedWordCountIsReturned()
        {
            int ITERATIONS = 1000;

            int MIN_COUNT = 0;
            int MAX_COUNT = 10000;

            Random random = new Random();

            for (int i = 0; i < ITERATIONS; i++)
            {
                int requestedCount = random.Next(MIN_COUNT, MAX_COUNT);
                int actualCount = generator.Words(requestedCount).Length;

                Assert.Equal(requestedCount, actualCount);
            }
        }

        /// <summary>
        /// Tests whether the generator always returns the number of sentences requested.
        /// </summary>
        [Fact]
        public void EnsureRequestedSentenceCountIsReturned()
        {
            int ITERATIONS = 1000;

            int MIN_COUNT = 0;
            int MAX_COUNT = 1000;

            Random random = new Random();

            for (int i = 0; i < ITERATIONS; i++)
            {
                int requestedCount = random.Next(MIN_COUNT, MAX_COUNT);
                int actualCount = generator.Sentences(requestedCount).Length;

                Assert.Equal(requestedCount, actualCount);
            }
        }

        /// <summary>
        /// Tests whether the generator always returns the number of paragraph requested.
        /// </summary>
        [Fact]
        public void EnsureRequestedParagraphCountIsReturned()
        {
            int ITERATIONS = 1000;

            int MIN_COUNT = 0;
            int MAX_COUNT = 1000;

            Random random = new Random();

            for (int i = 0; i < ITERATIONS; i++)
            {
                int requestedCount = random.Next(MIN_COUNT, MAX_COUNT);
                int actualCount = generator.Paragraphs(requestedCount).Length;

                Assert.Equal(requestedCount, actualCount);
            }
        }

    }
}
