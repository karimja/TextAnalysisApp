using System.Collections.Generic;

namespace TextAnalysisApp
{
    /// <summary>
    /// Logs Text Analysis results
    /// </summary>
    public interface ITextAnalysisLogger
    {
        void LogResults(Dictionary<string, int> wordCounts);
    }
}
