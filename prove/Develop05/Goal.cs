namespace Develop05;

public abstract class Goal
{
    private bool _completed;
    private string _name;
    private int _pointValue;
    private string _goalType;

    public Goal(string name, int pointValue, string goalType)
    {
        _name = name;
        _pointValue = pointValue;
        _goalType = goalType;
        _completed = false;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPointValue()
    {
        return _pointValue;
    }

    public string GetGoalType()
    {
        return _goalType;
    }

    public bool IsCompleted()
    {
        return _completed;
    }

    protected void SetCompleted(bool completed)
    {
        _completed = completed;
    }

    public abstract void Complete();

    public virtual void Display()
    {
        string status = _completed ? "X" : " ";
        Console.WriteLine($"[{status}] {_name} ({_pointValue} points)");
    }

    public abstract string GetSaveInfo();
}