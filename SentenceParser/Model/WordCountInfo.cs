using SentenceParser.Helper;
using System;
using System.ComponentModel;

namespace SentenceParser.Model
{
    public class WordCountInfo:IWordCountInfo
    {

        #region private fields

        private int _count = 0;

        #endregion

        #region Constructor

        public WordCountInfo(string word, int count)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new ArgumentNullException("word", Constants.WORD_EXCEPTION_MESSAGE);

            if (count < 0)
                throw new ArgumentOutOfRangeException("count", Constants.COUNT_EXCEPTION_MESSAGE);

            Word = word;
            Count = count;
        }

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

        #region IWordCountInfo Implementation

        /// <summary>
        /// Represents a single word
        /// </summary>
        public string Word { get; private set; }

        /// <summary>
        /// Number of occurences of the word
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                if (_count < 0)
                    throw new ArgumentOutOfRangeException("count", Constants.COUNT_EXCEPTION_MESSAGE);

                OnPropertyChanged("DisplayInfo");
            }
        }

        /// <summary>
        /// The display string word + count
        /// </summary>
        public string DisplayInfo
        {
            get
            {
                return Word + " - " + _count; ;
            }
        }

        #endregion
      
        #region IComparable Implementation

        /// <summary>
        /// Used in sorting of list 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return - 1;

            IWordCountInfo tocompare = (obj as IWordCountInfo);

            if (tocompare == null)
                return -1;

            if (tocompare.Count == this.Count)
                return 0;
            else if (tocompare.Count > this.Count)
                return 1;
            else
                return -1;

        }

        #endregion

    }
}
