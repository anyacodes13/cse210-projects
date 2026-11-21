namespace Develop05;

public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int pointValue)
        : base(name, pointValue, "Eternal")
    {
        _timesCompleted = 0;
    }

    public override void Complete()
    {
        _timesCompleted++;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] {GetName()} ({GetPointValue()} points) " +
                          $"Completed {_timesCompleted} times");
    }

    public override string GetSaveInfo()
    {
        return $"{GetGoalType()}|{GetName()}|{GetPointValue()}|{_timesCompleted}";
    }
}