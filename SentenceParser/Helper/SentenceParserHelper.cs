using SentenceParser.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SentenceParser.Helper
{
    public class SentenceParserHelper:ISentenceParserHelper
    {

        #region private fields

        /// <summary>
        /// The pattern only recognises words in ethe sentence.
        /// It will ignore numbers and special characters. 
        /// </summary>
        private const string _regexPattern = @"\w(?<!\d)[\w'-]*";

        #endregion

        #region ISentenceParserHelper implementation

        /// <summary>
        /// Parse a string into words and their occurences.
        /// </summary>
        /// <param name="sentence">string to be parsed into words</param>
        /// <returns>Dictionary of distinct words and their occurences in the string.</returns>
        public IDictionary<string, int> GetWordsCountDictionary(string sentence)
        {
            IDictionary<string, int> wordsCountDictionary = new Dictionary<string, int>();

            if (!string.IsNullOrWhiteSpace(sentence))
            {
                MatchCollection words = Regex.Matches(sentence, _regexPattern,RegexOptions.IgnoreCase);

                if (words != null && words.Count > 0)
                {
                    foreach (Match word in words)
                    {                      
                        if (!string.IsNullOrWhiteSpace(word.Value))
                        {
                            string key = word.Value.ToLower();
                            if (wordsCountDictionary.ContainsKey(key))
                            {
                                wordsCountDictionary[key]++;
                            }
                            else
                            {
                                wordsCountDictionary.Add(key, 1);
                            }
                        }
                    }
                }              
            }
            return wordsCountDictionary;
        }

        /// <summary>
        /// Updates the binded list with new words.
        /// </summary>
        /// <param name="bindedWordsCountList">Binded observable list </param>
        /// <param name="updatedWordList">New words dictionary</param>
        public void UpdateWordsCountList(ref ObservableCollection<IWordCountInfo> bindedWordsCountList, IDictionary<string, int> updatedWordList)
        {
            if (bindedWordsCountList == null || updatedWordList == null)
                return;

            // this list holds deleted words
            IList<IWordCountInfo> deletedWords = new List<IWordCountInfo>();

            foreach (IWordCountInfo item in bindedWordsCountList)
            {
                if (updatedWordList.ContainsKey(item.Word))
                {
                    // update word count
                    item.Count = updatedWordList[item.Word];
                    updatedWordList.Remove(item.Word);
                }
                else
                {
                    deletedWords.Add(item);
                }
            }

            foreach (IWordCountInfo deletedWord in deletedWords)
            {
                bindedWordsCountList.Remove(deletedWord);
            }

            // updatedWordList now has only new words.
            foreach (KeyValuePair<string,int> newword in updatedWordList)
            {
                bindedWordsCountList.Add(new WordCountInfo(newword.Key, newword.Value));
            }

            // sort it in order of word count
            bindedWordsCountList.BubbleSort();
        }

        #endregion

    }
}
