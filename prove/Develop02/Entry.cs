namespace Develop02;

public class Entry
{
    private DateTime _date = DateTime.Today;
    private string _response = string.Empty;
    private string _prompt = string.Empty;

    public Entry(string prompt, string userEntry)
    {
        _response = userEntry;
        _prompt = prompt;
    }

    public override string ToString()
    {
        return $"{_date:MM/dd/yyyy}\nPrompt: {_prompt}\nResponse: {_response}";
    }

    public string ToFileLine(string date, string prompt, string userEntry)
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public bool ContainsString(string words)
    {
        return _prompt.Contains(words) || _response.Contains(words);
    }
}