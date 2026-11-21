namespace Develop05;
public class GoalList
{
    private List<Goal> _goalList;
    private int _pointsEarned;
    private List<Milestone> _milestonesEarned;
    private List<Milestone> _existingMilestones;

    public GoalList()
    {
        _goalList = new List<Goal>();
        _pointsEarned = 0;
        _milestonesEarned = new List<Milestone>();

        _existingMilestones = new List<Milestone>
        {
            new Milestone("Beginner", 100),
            new Milestone("Dedicated", 500),
            new Milestone("Champion", 1000)
        };
    }

    public void AddGoal(Goal goal)
    {
        _goalList.Add(goal);
    }

    public void RemoveGoal(Goal goal)
    {
        _goalList.Remove(goal);
    }

    public List<Goal> GetGoalList()
    {
        return _goalList;
    }

    public int GetPointsEarned()
    {
        return _pointsEarned;
    }

    public void AddPoints(int points)
    {
        _pointsEarned += points;
        CheckMilestones();
    }

    public void CompleteGoal(Goal goal)
    {
        int oldTimesCompleted = 0;

        if (goal is EternalGoal eternalGoal)
        {
            oldTimesCompleted = eternalGoal.GetTimesCompleted();
        }
        else if (goal is ChecklistGoal checklistGoal)
        {
            oldTimesCompleted = checklistGoal.GetTimesCompleted();
        }

        goal.Complete();

        if (goal is SimpleGoal && goal.IsCompleted())
        {
            AddPoints(goal.GetPointValue());
        }
        else if (goal is EternalGoal)
        {
            AddPoints(goal.GetPointValue());
        }
        else if (goal is ChecklistGoal checklist)
        {
            if (checklist.GetTimesCompleted() > oldTimesCompleted)
            {
                AddPoints(goal.GetPointValue());

                if (checklist.IsCompleted() &&
                    checklist.GetTimesCompleted() == checklist.GetCompletionRequirement())
                {
                    AddPoints(checklist.GetBonus());
                }
            }
        }
    }

    public List<Milestone> GetEarnedMilestones()
    {
        return _milestonesEarned;
    }

    public string GetSaveInfo()
    {
        List<string> saveLines = new List<string>
        {
            $"POINTS|{_pointsEarned}"
        };

        foreach (Goal goal in _goalList)
        {
            saveLines.Add(goal.GetSaveInfo());
        }

        return string.Join(Environment.NewLine, saveLines);
    }

    private void CheckMilestones()
    {
        foreach (Milestone milestone in _existingMilestones)
        {
            if (_pointsEarned >= milestone.GetPointRequirement() &&
                !_milestonesEarned.Contains(milestone))
            {
                _milestonesEarned.Add(milestone);
                Console.WriteLine(
                    $"Milestone earned: {milestone.GetName()}!");
            }
        }
    }
}