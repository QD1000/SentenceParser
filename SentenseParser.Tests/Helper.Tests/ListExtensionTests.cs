using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceParser.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SentenceParser.Helper;

namespace SentenseParser.Tests.Helper.Tests
{
    [TestClass]
    public class ListExtensionTests
    {
 
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void BubbleSortNullElementTest()
        {
            ObservableCollection<IWordCountInfo>  wordCountList = new ObservableCollection<IWordCountInfo>();
            wordCountList.Add(null);
            wordCountList.Add(new WordCountInfo("test1", 1));
            wordCountList.Add(new WordCountInfo("test2", 2));           
            ListExtension.BubbleSort(wordCountList);
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void BubbleSortNotIComparableElementTest()
        {
            ObservableCollection<object> wordCountList = new ObservableCollection<object>();
            wordCountList.Add(new Object());
            wordCountList.Add(new WordCountInfo("test1", 1));
            wordCountList.Add(new WordCountInfo("test2", 2));
            ListExtension.BubbleSort(wordCountList);
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            ObservableCollection<object> wordCountList = new ObservableCollection<object>();
            WordCountInfo wc1 = new WordCountInfo("test1", 1);
            WordCountInfo wc2 = new WordCountInfo("test2", 2);
            WordCountInfo wc3 = new WordCountInfo("test3", 3);
            wordCountList.Add(wc1);
            wordCountList.Add(wc2);
            wordCountList.Add(wc3);
            ListExtension.BubbleSort(wordCountList);
            Assert.AreSame(wc1, wordCountList[2]);
            Assert.AreSame(wc2, wordCountList[1]);
            Assert.AreSame(wc3, wordCountList[0]);
        }


    }
}
