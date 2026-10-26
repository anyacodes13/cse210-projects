namespace Develop03;

public class Word
{
   
    private string _word;
    private string _punctuation;
    private bool _hidden =  false;

    public Word(string word)
    {
        _word = word;
        bool hasPunctuation = char.IsPunctuation(_word[^1]);
        if (hasPunctuation)
        {
            _punctuation = _word.Substring(_word.Length - 1);
            _word = _word.Substring(0, _word.Length - 1);
        }
        else
        {
            _punctuation = "";
        }
    }

    public void SetHidden(bool hidden)
    {
        _hidden = hidden;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public override string ToString()
    {
        if (!IsHidden())
        {
            return _word + _punctuation;
        }
        else
        {
            return new string('_', _word.Length) + _punctuation;
        }
    }
}