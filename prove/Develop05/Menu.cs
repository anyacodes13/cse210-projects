namespace Develop05;

public class Menu
{
    private List<string> _options;
    private GoalList _goalList;
    private File _fileManager;
    private GoalSuggestions _goalSuggestions;

    public Menu()
    {
        _options = new List<string>
        {
            "Create New Goal",
            "List Goals",
            "Record Event",
            "Display Score",
            "Save Goals",
            "Load Goals",
            "Goal Suggestions",
            "Quit"
        };

        _goalList = new GoalList();
        _fileManager = new File();
        _goalSuggestions = new GoalSuggestions();
    }

    public void Display()
    {
        Console.WriteLine(
            $"\nYou have {_goalList.GetPointsEarned()} points.\n");

        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_options[i]}");
        }
    }

    public void UserInput()
    {
        bool running = true;

        while (running)
        {
            Display();
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    Console.WriteLine(
                        $"Total score: {_goalList.GetPointsEarned()}");
                    break;

                case "5":
                    _fileManager.Save(_goalList);
                    break;

                case "6":
                    _goalList = _fileManager.Load();
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                
                case "7":
                    _goalSuggestions.DisplaySuggestions(_goalList);
                    break;

                case "8":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");
        string type = Console.ReadLine() ?? "";

        Console.Write("Goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Point value: ");
        int pointValue = int.Parse(Console.ReadLine() ?? "0");

        if (type == "1")
        {
            _goalList.AddGoal(new SimpleGoal(name, pointValue));
        }
        else if (type == "2")
        {
            _goalList.AddGoal(new EternalGoal(name, pointValue));
        }
        else if (type == "3")
        {
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Completion requirement: ");
            int requirement = int.Parse(Console.ReadLine() ?? "1");

            _goalList.AddGoal(
                new ChecklistGoal(
                    name,
                    pointValue,
                    bonus,
                    requirement));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");

        List<Goal> goals = _goalList.GetGoalList();

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].Display();
        }
    }

    private void RecordEvent()
    {
        List<Goal> goals = _goalList.GetGoalList();

        if (goals.Count == 0)
        {
            Console.WriteLine("There are no goals yet.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you complete? ");
        int choice = int.Parse(Console.ReadLine() ?? "1");

        if (choice >= 1 && choice <= goals.Count)
        {
            _goalList.CompleteGoal(goals[choice - 1]);
            Console.WriteLine("Event recorded.");
        }
    }
}