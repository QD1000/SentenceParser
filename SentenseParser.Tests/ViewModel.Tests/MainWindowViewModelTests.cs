using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentenceParser.ViewModel;
using SentenceParser.Helper;

namespace SentenseParser.Tests.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _mainWindowViewModel;

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MainWindowViewModelConstructorNullTest()
        {
            _mainWindowViewModel = new MainWindowViewModel(null);
        }

        [TestMethod]
        public void SentenceParserViewModelTest()
        {
            ISentenceParserViewModel sentenceParserViewModel = new SentenceParserViewModel(new SentenceParserHelper());
            _mainWindowViewModel = new MainWindowViewModel(sentenceParserViewModel);
            Assert.AreSame(sentenceParserViewModel, _mainWindowViewModel.SentenceParserViewModel);
        }

    }
}
