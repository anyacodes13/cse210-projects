namespace Develop05;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int pointValue)
        : base(name, pointValue, "Simple")
    {
    }

    public override void Complete()
    {
        if (!IsCompleted())
        {
            SetCompleted(true);
        }
    }

    public override string GetSaveInfo()
    {
        return $"{GetGoalType()}|{GetName()}|{GetPointValue()}|{IsCompleted()}";
    }
}


