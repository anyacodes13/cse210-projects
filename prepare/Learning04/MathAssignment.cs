namespace Learning04;

public class MathAssignment : Assignment
{
    private string _texbookSection;
    private string _problems;

    public MathAssignment(
        string studentName,
        string topic,
        string textbookSection,
        string problems
    ) : base(studentName, topic)
    {
        _texbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return "Section " + _texbookSection + " Problems " + _problems;
    }
}