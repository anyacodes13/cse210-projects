namespace Develop02;

public class Menu
{
    private int _userSelection;
    private string _prompt;
    private bool _end = false;
    Journal journal = new Journal();
    private string _liveJournal;
    List<string> _loadedJournal;
    

    public void Run()
    {
        while (_end != true)
        {
            Console.WriteLine(
                "Please select one of the following options:\n1. Write\n2. Display\n3. Save\n4. Load\n5. Search Journal\n6. Exit\n What would you like to do? ");
            _userSelection = Convert.ToInt32(Console.ReadLine());
            if (_userSelection == 1)
            {
                Write();
            }

            if (_userSelection == 2)
            {
                Display();
            }

            if (_userSelection == 3)
            {
                Save();
            }

            if (_userSelection == 4)
            {
                Load();
            }

            if (_userSelection == 5)
            {
                Search();
            }
            if (_userSelection == 6)
            {
                Exit();
            }
        }
    }
    public void Write()
    {
        PromptGenerator prompt = new PromptGenerator();
        Console.Clear();
        _prompt = prompt.GetPrompt();
        Console.Write(prompt.GetPrompt());
        string entry = Console.ReadLine();
        journal.AddEntry(_prompt, entry);
        return;
        
    }

    public void Display()
    {
        _liveJournal = journal.DisplayEntries();
        Console.WriteLine(_liveJournal);
        return;
    }

    public void Save()
    {
        string journalToSave = journal.CompileBook();
        Console.WriteLine("Where would you like to save the file? ");
        string fileLocation = Console.ReadLine();
        JournalFile file = new JournalFile();
        file.fileSave(fileLocation, journalToSave);
        return;
    }

    public void Load()
    {
        JournalFile file = new JournalFile();
        Console.WriteLine("Where would you like to get the file from? ");
        string fileLocation = Console.ReadLine();
        _loadedJournal = file.fileLoad(fileLocation);
        foreach (string entry in _loadedJournal)
        {
            Console.WriteLine(entry);
        }

        return;
    }

    public void Search()
    {
        Console.Write("What would you like to search for? ");
        string searchWord = Console.ReadLine();
        Search search = new Search();
        Console.WriteLine(search.DisplaySearchedEntries(journal.GetListOfEntries(_loadedJournal), searchWord));
    }
    public void Exit()
    {
        _end = true;
        return;
    }
}