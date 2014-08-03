using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysisApp
{
    /// <summary>
    /// Outputs Text Analysis results to console
    /// </summary>
    public class TextAnalysisConsoleLogger : ITextAnalysisLogger
    {
        /// <summary>
        /// Output Word counts to console
        /// </summary>
        /// <param name="wordCounts">List of Unique words and associated counts</param>
        public void LogResults(Dictionary<string, int> wordCounts)
        {
            if (wordCounts == null || wordCounts.Count == 0)
            {
                Console.WriteLine("No words found");
                return;
            }

            foreach (var wordCount in wordCounts)
            {
                Console.WriteLine("{0} - {1}", wordCount.Key, wordCount.Value);
            }

        }
    }
}
