namespace Develop05;

public class ChecklistGoal : Goal
{
    private int _completionRequirement;
    private int _timesCompleted;
    private int _bonus;

    public ChecklistGoal(
        string name,
        int pointValue,
        int bonus,
        int completionRequirement)
        : base(name, pointValue, "Checklist")
    {
        _completionRequirement = completionRequirement;
        _timesCompleted = 0;
        _bonus = bonus;
    }

    public override void Complete()
    {
        if (_timesCompleted < _completionRequirement)
        {
            _timesCompleted++;

            if (_timesCompleted >= _completionRequirement)
            {
                SetCompleted(true);
            }
        }
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public int GetCompletionRequirement()
    {
        return _completionRequirement;
    }

    public override void Display()
    {
        string status = IsCompleted() ? "X" : " ";
        Console.WriteLine(
            $"[{status}] {GetName()} ({GetPointValue()} points) " +
            $"-- Completed {_timesCompleted}/{_completionRequirement} times");
    }

    public override string GetSaveInfo()
    {
        return $"{GetGoalType()}|{GetName()}|{GetPointValue()}|" +
               $"{_bonus}|{_completionRequirement}|{_timesCompleted}";
    }
}