using System.Collections.Generic;

namespace TextAnalysisApp
{
    /// <summary>
    /// Text Analysis
    /// </summary>
    public interface ITextAnalyzer
    {
        Dictionary<string, int> CountDistinctWords(string text);
    }
}
