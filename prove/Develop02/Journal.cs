using System.Security.Cryptography.X509Certificates;

namespace Develop02;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string _liveJournal;

    public void AddEntry(string prompt, string userEntry)
    {
        _entries.Add(new Entry(prompt, userEntry));
        return;
    }

    public string DisplayEntries()
    {
        var response = "";
        foreach (Entry entry in _entries)
        {
            response += entry.ToString() + Environment.NewLine;
        }

        return response;
    }

    public string CompileBook()
    {
        string fileText = "";
        foreach (Entry entry in _entries)
        {
            // string[] parts = entry.Split('\n');
            string _oneEntry = entry.ToFileLine("", "", "");
            fileText += _oneEntry + Environment.NewLine;
        }

        return fileText;
    }

    // public List<string> GetListOfEntries(List<string> list)
    // {
    //     if (list == null || list.Count == 0)
    //     {
    //         return _entries;
    //     }
    //     else
    //     {
    //         return  list;
    //     }
    // }

    public string Search(string searchWord)
    {
        string response = "";
        foreach (var entry in _entries)
        {
            if (entry.ContainsString(searchWord))
                response += entry + Environment.NewLine;
        }

        return response;
    }
}
