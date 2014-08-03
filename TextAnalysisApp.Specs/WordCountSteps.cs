using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextAnalysisApp.Specs
{
    [Binding]
    public class WordCountSteps
    {
        Dictionary<string, int> _wordCounts;
        string _sentence;

        [Given(@"a sentence")]
        public void GivenASentence()
        {
            _sentence = "This is a statement, and so is this.";
        }

        [When(@"text Analyzer is run")]
        public void WhenTextAnalyzerIsRun()
        {
            var ta = new TextAnalyzer();
            _wordCounts = ta.CountDistinctWords(_sentence);
        }

        [Then(@"return a distinct list of words in the sentence and the number of times thay have occurred")]
        public void ThenReturnListOfWordsAndCounts()
        {
            Assert.AreEqual(_wordCounts.Count, 6);
            Assert.AreEqual(_wordCounts["this"], 2);
            Assert.AreEqual(_wordCounts["is"], 2);
            Assert.AreEqual(_wordCounts["a"], 1);
            Assert.AreEqual(_wordCounts["statement"], 1);
            Assert.AreEqual(_wordCounts["and"], 1);
            Assert.AreEqual(_wordCounts["so"], 1);
        }

        [Given(@"a empty sentence")]
        public void GivenAnEmptySentence()
        {
            _sentence = string.Empty;
        }


        [Then(@"return an empty list")]
        public void ThenReturnAnEmptyListOfWordsAndCounts()
        {
            Assert.AreEqual(_wordCounts.Count, 0);
        }

        [Given(@"a sentence only contains numbers")]
        public void GivenASentenceOfNumbers()
        {
            _sentence = "2 3 4444 55 6";
        }


        [Given(@"a sentence is null")]
        public void GivenSentenceIsNull()
        {
            _sentence = null;
        }

        [When(@"text Analyzer is run with a null sentence")]
        public void WhenTextAnalyzerIsRunWithNullSentence()
        {
            try
            {
                var ta = new TextAnalyzer();
                _wordCounts = ta.CountDistinctWords(_sentence);
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Add("Exception_NullSentence", e);
            } 
        }

        [Then(@"an exception is thrown")]
        public void ThenAnExceptionisThrown()
        {
            var exception = ScenarioContext.Current["Exception_NullSentence"];
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
        }

        [Given(@"a sentence with non-letter characters")]
        public void GivenASentenceOfWordsWithNonLetters()
        {
            _sentence = "This? is! a statement, and so is this.";
        }
    }
}
