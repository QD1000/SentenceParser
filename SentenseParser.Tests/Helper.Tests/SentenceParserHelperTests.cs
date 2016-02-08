using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceParser.Helper;
using System.Collections.Generic;
using SentenceParser.Model;
using System.Collections.ObjectModel;

namespace SentenseParser.Tests.Helper.Tests
{
    [TestClass]
    public class SentenceParserHelperTests
    {
        private ISentenceParserHelper _sentenceParserHelper = new SentenceParserHelper();
        private IDictionary<string, int> _wordsCountDictionary;

        [TestMethod]
        public void GetWordsCountDictionaryNullTest()
        {
            _wordsCountDictionary = _sentenceParserHelper.GetWordsCountDictionary(null);
            Assert.AreEqual(0, _wordsCountDictionary.Count);

        }

        [TestMethod]
        public void GetWordsCountDictionaryTest()
        {
            string teststring = @"this is a test 123 34string  $%%^%^  to Test String parsing.";

            _wordsCountDictionary = _sentenceParserHelper.GetWordsCountDictionary(teststring);
            Assert.AreEqual(7, _wordsCountDictionary.Count);
            Assert.IsTrue( _wordsCountDictionary.ContainsKey("string"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("test"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("this"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("is"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("a"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("to"));
            Assert.IsTrue(_wordsCountDictionary.ContainsKey("parsing"));
            Assert.IsFalse(_wordsCountDictionary.ContainsKey("123"));
            Assert.IsFalse(_wordsCountDictionary.ContainsKey("34string"));
            Assert.IsFalse(_wordsCountDictionary.ContainsKey("$%%^%^"));
            Assert.AreEqual(2, _wordsCountDictionary["string"]);
            Assert.AreEqual(2, _wordsCountDictionary["test"]);
            Assert.AreEqual(1, _wordsCountDictionary["this"]);
            Assert.AreEqual(1, _wordsCountDictionary["is"]);
            Assert.AreEqual(1, _wordsCountDictionary["a"]);
            Assert.AreEqual(1, _wordsCountDictionary["to"]);
            Assert.AreEqual(1, _wordsCountDictionary["parsing"]);

        }
     
        [TestMethod]
        public void GUpdateWordsCountListTest()
        {
            string teststring = "this is a test string to Test  String parsing test.";
            _wordsCountDictionary = _sentenceParserHelper.GetWordsCountDictionary(teststring);
            ObservableCollection<IWordCountInfo> bindedlist = new ObservableCollection<IWordCountInfo>();

            _sentenceParserHelper.UpdateWordsCountList(ref bindedlist, _wordsCountDictionary);
            Assert.AreEqual(7, bindedlist.Count);
            Assert.AreEqual(3, bindedlist[0].Count);
            Assert.AreEqual("test", bindedlist[0].Word);

            teststring = "this is a test string to Test  String test.";
            _wordsCountDictionary = _sentenceParserHelper.GetWordsCountDictionary(teststring);
            _sentenceParserHelper.UpdateWordsCountList(ref bindedlist, _wordsCountDictionary);
            Assert.AreEqual(6, bindedlist.Count);
            Assert.AreEqual(3, bindedlist[0].Count);
            Assert.AreEqual("test", bindedlist[0].Word);

            teststring = "this is a test string to Test  String test string string who.";
            _wordsCountDictionary = _sentenceParserHelper.GetWordsCountDictionary(teststring);
            _sentenceParserHelper.UpdateWordsCountList(ref bindedlist, _wordsCountDictionary);
            Assert.AreEqual(7, bindedlist.Count);
            Assert.AreEqual(4, bindedlist[0].Count);
            Assert.AreEqual("string", bindedlist[0].Word);



        }


     }
}
