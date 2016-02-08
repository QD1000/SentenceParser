using System;
using System.ComponentModel;

namespace SentenceParser.Model
{

    public interface IWordCountInfo: INotifyPropertyChanged, IComparable
    {
        string Word { get;  }
        int Count { get; set; }
        string DisplayInfo { get; }
    }
}
