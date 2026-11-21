namespace Develop05;

public class File
{
    private string _saveLocation;

    public File()
    {
        _saveLocation = "goals.txt";
    }

    public void Save(GoalList goalList)
    {
        System.IO.File.WriteAllText(
            _saveLocation, goalList.GetSaveInfo());

        Console.WriteLine("Goals saved successfully.");
    }

    public GoalList Load()
    {
        GoalList goalList = new GoalList();

        if (!System.IO.File.Exists(_saveLocation))
        {
            return goalList;
        }

        string[] lines = System.IO.File.ReadAllLines(_saveLocation);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts[0] == "POINTS")
            {
                goalList.AddPoints(int.Parse(parts[1]));
            }
            else if (parts[0] == "Simple")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    int.Parse(parts[2]));

                if (bool.Parse(parts[3]))
                {
                    goal.Complete();
                }

                goalList.AddGoal(goal);
            }
            else if (parts[0] == "Eternal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1], int.Parse(parts[2]));

                int timesCompleted = int.Parse(parts[3]);

                for (int i = 0; i < timesCompleted; i++)
                {
                    goal.Complete();
                }

                goalList.AddGoal(goal);
            }
            else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));

                int timesCompleted = int.Parse(parts[5]);

                for (int i = 0; i < timesCompleted; i++)
                {
                    goal.Complete();
                }

                goalList.AddGoal(goal);
            }
        }

        return goalList;
    }
}