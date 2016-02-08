using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceParser.Model;
using System.ComponentModel;
using SentenceParser.Helper;

namespace SentenseParser.Tests.Model.Tests
{
    [TestClass]
    public class WordCountInfoTests
    {
        private IWordCountInfo _wordCountInfo;

        [TestMethod]
        public void DisplayInfoTests()
        {
            _wordCountInfo = new WordCountInfo("test",3);
            Assert.AreEqual<string>("test - 3", _wordCountInfo.DisplayInfo);
        }

        [TestMethod]
        public void CompareToTests()
        {
            _wordCountInfo = new WordCountInfo("test", 3);
            IWordCountInfo _wordCountInfoEqual = new WordCountInfo("test1", 3); ;
            IWordCountInfo _wordCountInfoGreater = new WordCountInfo("test2", 4); ;
            IWordCountInfo _wordCountInfoLesser = new WordCountInfo("test3", 2); ;

            Assert.AreEqual<int>(0, _wordCountInfo.CompareTo(_wordCountInfoEqual));
            Assert.AreEqual<int>(-1, _wordCountInfo.CompareTo(_wordCountInfoLesser));
            Assert.AreEqual<int>(1, _wordCountInfo.CompareTo(_wordCountInfoGreater));
            Assert.AreEqual<int>(-1, _wordCountInfo.CompareTo(null));
            Assert.AreEqual<int>(-1, _wordCountInfo.CompareTo(new Object()));
        }

        [TestMethod]
        public void OnPropertyChangedTests()
        {
            _wordCountInfo = new WordCountInfo("test", 3);
            string propertyName = string.Empty;
            _wordCountInfo.PropertyChanged +=delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyName = e.PropertyName;
            };
            _wordCountInfo.Count = 4;
            Assert.AreEqual<string>("DisplayInfo", propertyName);
        }

        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWordNullExceptionTest()
        {
            _wordCountInfo = new WordCountInfo("", 3);
        }

        [TestMethod,ExpectedException(typeof(ArgumentOutOfRangeException)),]
        public void ConstructorCountNegativeExceptionTest()
        {
            _wordCountInfo = new WordCountInfo("test", -3);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException)),]
        public void CountNegativeExceptionTest()
        {
            _wordCountInfo = new WordCountInfo("test",0);
            _wordCountInfo.Count = -1;
        }

    }
}
