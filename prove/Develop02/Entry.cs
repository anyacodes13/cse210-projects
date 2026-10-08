namespace Develop02;

public class Entry
{
    private DateTime _date = DateTime.Today;
    private string _response = string.Empty;

    public string CreateEntry(string prompt, string userEntry)
    {
        _response = userEntry;

        return $"{_date:MM/dd/yyyy}\nPrompt: {prompt}\nResponse: {_response}";
        
    }
    
    public string toFileLine(string date, string prompt, string userEntry)
    {
        return $"{date}|{prompt}|{userEntry}";
    }
}