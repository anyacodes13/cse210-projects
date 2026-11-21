namespace Develop05;

public class Milestone
{
    private string _name;
    private int _pointCost;

    public Milestone(string name, int pointCost)
    {
        _name = name;
        _pointCost = pointCost;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPointRequirement()
    {
        return _pointCost;
    }

    public string GetSaveInfo()
    {
        return $"{_name}|{_pointCost}";
    }

    public void Display()
    {
        Console.WriteLine($"{_name} - {_pointCost} points");
    }
}