namespace Develop02;

public class JournalFile
{
    private List<string> _journalBook = new List<string>();
    
    public void FileSave(string fileLocation, string journal)
    {
        File.WriteAllText(fileLocation, journal);

        Console.WriteLine("The file was saved.");
    }

    public List<string> FileLoad(string fileLocation)
    {
        string journal = File.ReadAllText(fileLocation);
        // _entries.Clear();
        
        string[] lines = journal.Split(
            Environment.NewLine,
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string line in lines)
        {
            string[] parts = line.Split('|', 3);

            if (parts.Length == 3)
            {
                string entry = $"{parts[0]}\n{parts[1]}\n{parts[2]}";
                _journalBook.Add(entry);
            }
        }
        return _journalBook;
    }
}