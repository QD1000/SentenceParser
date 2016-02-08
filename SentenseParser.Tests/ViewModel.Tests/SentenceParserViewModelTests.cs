using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceParser.ViewModel;
using SentenceParser.Helper;
using System.ComponentModel;

namespace SentenseParser.Tests.ViewModel.Tests
{
    [TestClass]
    public class SentenceParserViewModelTests
    {
        private ISentenceParserViewModel _sentenceParserViewModel;

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SentenceParserViewModelConstructorNullTest()
        {
            _sentenceParserViewModel = new SentenceParserViewModel(null);
        }

        [TestMethod]
        public void OnPropertyChangedTests()
        {
            _sentenceParserViewModel = new SentenceParserViewModel(new SentenceParserHelper());
            string propertyName = string.Empty;
            _sentenceParserViewModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyName = e.PropertyName;
            };        
            _sentenceParserViewModel.Sentence = "this is a test string";
            Assert.AreEqual<string>("WordsCountList", propertyName);
        }

        [TestMethod]
        public void SentenceUpdatedTests()
        {
            _sentenceParserViewModel = new SentenceParserViewModel(new SentenceParserHelper());
            Assert.AreEqual(0,_sentenceParserViewModel.WordsCountList.Count);
            _sentenceParserViewModel.Sentence = "this is a test string";
            Assert.AreEqual(5, _sentenceParserViewModel.WordsCountList.Count);
            _sentenceParserViewModel.Sentence = "this is a test string to test";
            Assert.AreEqual(6, _sentenceParserViewModel.WordsCountList.Count);
        }
    }
}
