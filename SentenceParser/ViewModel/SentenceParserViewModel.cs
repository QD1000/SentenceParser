using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SentenceParser.Model;
using SentenceParser.Helper;

namespace SentenceParser.ViewModel
{
    public class SentenceParserViewModel : ISentenceParserViewModel
    {
        #region Private fields

        private string _sentence;
        private ObservableCollection<IWordCountInfo> _wordsCountBindedList;
        private readonly ISentenceParserHelper _sentenceParserHelper;

        #endregion

        #region INotifyPropertyChanged Implementation
      
        /// <summary>
        /// Fires when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Constructor

        public SentenceParserViewModel(ISentenceParserHelper sentenceParserHelper)
        {
            if (sentenceParserHelper == null)
                throw new ArgumentNullException(Constants.HELPER_NULL_EXCEPTION_MESSAGE);

            _sentenceParserHelper = sentenceParserHelper;
            _wordsCountBindedList = new ObservableCollection<IWordCountInfo>();
        }

        #endregion

        #region ISentenceParserViewModel implementation

        /// <summary>
        /// User entered string.
        /// </summary>
        public string Sentence
        {
            set
            {
                _sentence = value;
                RefreshResult();
            }
        }

        /// <summary>
        /// List of words and their occurences. 
        /// </summary>
        public IList<IWordCountInfo> WordsCountList
        {
            get
            {
                return _wordsCountBindedList;
            }
        }

        #endregion

        #region private methods

        private void RefreshResult()
        {            
                _sentenceParserHelper.UpdateWordsCountList(ref _wordsCountBindedList, _sentenceParserHelper.GetWordsCountDictionary(_sentence));
                OnPropertyChanged("WordsCountList");
        }

        #endregion

    }
}
