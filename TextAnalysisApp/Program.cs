using System;
using System.Collections.Generic;
using System.Linq;
namespace TextAnalysisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get Unqiue words and associated counts
            var wordCounts = new TextAnalyzer().CountDistinctWords("This is a statement, and so is this.");

            // Output Unqiue words and associated counts
            new TextAnalysisConsoleLogger().LogResults(wordCounts);

            Console.ReadLine();
        }
    }
}
