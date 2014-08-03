using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysisApp
{
    /// <summary>
    /// The analyzer will implement text analysis functionality e.g counting occurence of unique words within a sentence
    /// </summary>
    public class TextAnalyzer : ITextAnalyzer
    {
        /// <summary>
        /// Counts occurence of unique words within a sentence
        /// </summary>
        /// <param name="text">Input Text</param>
        /// <returns>List of unique words and associated counts</returns>
        public Dictionary<string, int> CountDistinctWords(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }

            var wordCounts = new Dictionary<string, int>();

            var words = ExtractWords(text);

            foreach (var word in words)
            {
                var lowercaseWord = word.ToLower();

                if (!wordCounts.Keys.Contains(lowercaseWord))
                {
                    wordCounts.Add(lowercaseWord, 0);
                }

                wordCounts[lowercaseWord] = wordCounts[lowercaseWord] + 1;
            }

            return wordCounts;
        }

        /// <summary>
        /// A list of pre-defined sperators could be specified, but we can never ensure that list is exahustive
        /// and will cater for every possibility. Therefore, we will determine the seperator characters by assuming that 
        /// any character which is not a letter is deemed to be a separator.
        /// </summary>
        /// <param name="text">Input text that will be analyzed for seperators</param>
        /// <returns>Separator characters</returns>
        private static char[] ExtractSeparators(string text)
        {
            HashSet<char> separators = new HashSet<char>();

            foreach (char character in text)
            {
                // If the character is not a letter,
                // then by definition it is a separator
                if (!char.IsLetter(character))
                {
                    separators.Add(character);
                }
            }

            return separators.ToArray();
        }

        /// <summary>
        /// Split the text into seperate words
        /// </summary>
        /// <param name="text">Input text that will be split into seperate words</param>
        /// <returns>List of words that have been extracted from the text</returns>
        private static string[] ExtractWords(string text)
        {
            char[] separators = ExtractSeparators(text);

            string[] words = text.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
    }
}
