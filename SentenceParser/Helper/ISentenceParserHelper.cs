using SentenceParser.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SentenceParser.Helper
{
    public interface ISentenceParserHelper
    {
        IDictionary<string, int> GetWordsCountDictionary(string sentence);
        void UpdateWordsCountList(ref ObservableCollection<IWordCountInfo> wordsCountList, IDictionary<string, int> updatedWordsDictionary);
    }
}
