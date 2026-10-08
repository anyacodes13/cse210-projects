namespace Develop02;

public class Search
{
    private string _liveJournal;
    
    public string DisplaySearchedEntries(List<string> journal, string searchWord)
    {
        foreach (string entry in journal)
            if (entry.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
            {
                _liveJournal += entry + Environment.NewLine;
            }
        return _liveJournal;
        
    }
}