using System.Security.Cryptography.X509Certificates;

namespace Develop02;

public class Journal
{
    private List<string> _entries = new List<string>();
    private string _liveJournal;
    Entry _entry = new Entry();

    public void AddEntry(string prompt, string userEntry)
    {
        _entries.Add(_entry.CreateEntry(prompt, userEntry));
        return;
    }

    public string DisplayEntries()
    {
        foreach (string entry in _entries)
        {
            _liveJournal += entry + Environment.NewLine;
        }

        return _liveJournal;
    }

    public string CompileBook()
    {
        string fileText = "";
        foreach (string entry in _entries)
        {
            string[] parts = entry.Split('\n');
            string _oneEntry = _entry.toFileLine(parts[0], parts[1], parts[2]);
            fileText += _oneEntry + Environment.NewLine;
        }

        return fileText;
    }

    public List<string> GetListOfEntries(List<string> list)
    {
        if (list == null || list.Count == 0)
        {
            return _entries;
        }
        else
        {
            return  list;
        }
    }
}
