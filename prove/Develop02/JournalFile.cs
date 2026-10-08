namespace Develop02;

public class JournalFile
{
    private List<string> journalBook = new List<string>();
    
    public void fileSave(string _fileLocation, string _journal)
    {
        File.WriteAllText(_fileLocation, _journal);

        Console.WriteLine("The file was saved.");
    }

    public List<string> fileLoad(string _fileLocation)
    {
        string journal = File.ReadAllText(_fileLocation);
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
                journalBook.Add(entry);
            }
        }
        return journalBook;
    }
}