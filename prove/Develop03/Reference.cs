/* Stretch challenges and creativity:
 *
 * 1. I created a library containing three different scriptures so the user
 *    can choose which scripture to practice.
 *
 * 2. I added an option for the user to enter a custom scripture, including
 *    the book, chapter, verse or verse range, and scripture text.
 *
 * 3. I completed the stretch challenge by making sure the program only
 *    chooses words that have not already been hidden. This prevents the
 *    program from selecting the same hidden word repeatedly.
 */

namespace Develop03; 

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _endVerse = verse;
        _startVerse = verse;
        
    }
    public Reference(string book, int chapter, int startVerse, int endVerse){
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}