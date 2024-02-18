using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace IEDSInterface
{
    public interface IEDSParser//:IWin32Window
    {
        StringDictionary GetProperties(string source);
        ICollection Keys { get; }
        string ParserFileTypes { get; set; }
        //used by each UI to filter the results.....based on this property the file dispatcher will 
        //set the apropriate content types like it updates GlobalData.DocFileTypes if the parser is for a document file
        string ParserCategory { get; } 
    }
}
