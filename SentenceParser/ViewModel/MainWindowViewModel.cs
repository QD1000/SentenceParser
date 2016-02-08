using SentenceParser.Helper;
using System;

namespace SentenceParser.ViewModel
{
    public class MainWindowViewModel
    {
        #region Private fields

        private readonly ISentenceParserViewModel _sentenceParserViewModel;

        #endregion

        #region Constructor

        public MainWindowViewModel(ISentenceParserViewModel sentenceParserViewModel)
        {
            if (sentenceParserViewModel == null)
                throw new ArgumentNullException(Constants.VIEWMODEL_NULL_EXCEPTION_MESSAGE);

            _sentenceParserViewModel = sentenceParserViewModel;
        }

        #endregion

        #region Public method

        public ISentenceParserViewModel SentenceParserViewModel
        {
            get
            {
                return _sentenceParserViewModel;
            }
        }

        #endregion

    }
}
