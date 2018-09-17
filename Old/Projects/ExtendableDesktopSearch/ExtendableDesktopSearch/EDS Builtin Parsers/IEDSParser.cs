using System.Collections.Specialized;
using System.Collections;
using System.Windows.Forms;
namespace ExtendableDesktopSearch
{
    /// <summary>
    /// This interface provides the blueprint for a parser
    /// </summary>
    public interface IEDSParser//:IWin32Window
    {
        StringDictionary GetProperties(string source);
        ICollection Keys { get;}
        string ParserFileTypes { get;set;}
    }
}
