namespace Develop03; 

public class Scripture
{
    
    private Reference _reference;
    private List<Word> _words;
    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string wordText in text.Split(' '))
        {
            _words.Add(new Word(wordText));
        }
    }
    
    public override string ToString()
    {
        string result = _reference.ToString() + " \n";

        foreach (Word word in _words)
        {
            result += word.ToString();
            result += " ";
        }

        return result;
    }
    
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if ( word.IsHidden() == false)
            {
                return false;
            } 
        }
        return true;
    }
    
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].SetHidden(true);
                hiddenCount++;
            }
        }
    }
    
    public string GetReference()
    {
        return _reference.ToString();
    }
}