using SentenceParser.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace SentenceParser.ViewModel
{
    public interface ISentenceParserViewModel: INotifyPropertyChanged
    {
        string Sentence { set; }
        IList<IWordCountInfo> WordsCountList { get; }
    }
}
