using System;
using System.Linq;

namespace DummyText.Utils
{
    public static class CommonCharacterGroups
    {

        /// <summary>
        /// Check whether the input contains any of the items in the target array.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool Contains(string input, string[] target, StringComparison stringComparison = StringComparison.Ordinal)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (input.Contains(target[i]))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check whether the input is contained in the target array.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool Is(string input, string[] target, StringComparison stringComparison = StringComparison.Ordinal)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (input.Equals(target[i], stringComparison))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check whether the input is contained in the target array.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="target"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool Is(char input, string[] target, StringComparison stringComparison = StringComparison.Ordinal)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if (input.Equals(target[i][0]))
                    return true;
            }

            return false;
        }

        public static class English
        {
            public static string[] PunctuationMark => new string[]
            {
                ".", ",", "!", "?"
            };

            public static string[] SentenceTerminator => new string[]
            {
                ".", "!", "?"
            };

            public static readonly string[] AlphabeticalLowerCase =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            /// <summary>
            /// Backing field (used as a cache) for AlphabeticalUpperCase
            /// </summary>
            private static string[] alphabeticalUpperCase;
            public static string[] AlphabeticalUpperCase =
                alphabeticalUpperCase ??= AlphabeticalLowerCase.Select(x => x.ToUpper()).ToArray();

            /// <summary>
            /// Backing field (used as a cache) for Alphabetical
            /// </summary>
            private static string[] alphabetical;
            public static string[] Alphabetical =
                alphabetical ??= CommonCharacterGroups.Join<string>(AlphabeticalLowerCase, AlphabeticalUpperCase);

            public static readonly string[] Numerical =
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
            };

            /// <summary>
            /// Backing field (used as a cache) for AlphaNumerical
            /// </summary>
            private static string[] alphaNumerical;
            public static string[] AlphaNumerical =>
                alphaNumerical ??= CommonCharacterGroups.Join<string>(Alphabetical, Numerical);
        }

        /// <summary>
        /// Join 2 arrays together by copying their contents into a new array.
        /// </summary>
        /// <typeparam name="T">The type of array to copy.</typeparam>
        /// <param name="a">The first array.</param>
        /// <param name="b">The second array.</param>
        /// <returns>The resulting array.</returns>
        private static T[] Join<T>(T[] a, T[] b)
        {
            int totalLength = a.Length + b.Length;

            T[] result = new T[totalLength];

            // copy a into the result array
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i];
            }

            // copy b into the result array, offset by a.length
            for (int i = 0; i < b.Length; i++)
            {
                result[i + a.Length] = b[i];
            }

            return result;
        }
    }
}
