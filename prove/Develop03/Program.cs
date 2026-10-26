using System;
using Develop03;

class Program
{
    static Scripture[] CreateScriptures()
    {
        Reference reference1 = new Reference("3 Nephi", 5, 13);
        Reference reference2 = new Reference("1 Corinthians", 13, 4, 8);
        Reference reference3 = new Reference("Mosiah", 2, 41);

        Scripture scripture1 = new Scripture(reference1, "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life.");
        Scripture scripture2 = new Scripture(reference2, "4 Charity suffereth long, and is kind; charity envieth not; charity vaunteth not itself, is not puffed up, 5 Doth not behave itself unseemly, seeketh not her own, is not easily provoked, thinketh no evil; 6 Rejoiceth not in iniquity, but rejoiceth in the truth; 7 Beareth all things, believeth all things, hopeth all things, endureth all things. 8 Charity never faileth: but whether there be prophecies, they shall fail; whether there be tongues, they shall cease; whether there be knowledge, it shall vanish away.");
        Scripture scripture3 = new Scripture(reference3, "And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. For behold, they are blessed in all things, both temporal and spiritual; and if they hold out faithful to the end they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. O remember, remember that these things are true; for the Lord God hath spoken it.");

        Scripture[] scriptures = { scripture1, scripture2, scripture3 };

        return scriptures;
    }

    static Scripture CreateCustomScripture()
    {
        string book = GetRequiredText("Enter the book: ");

        int chapter = GetNumber("Enter the chapter: ", 1);

        int startVerse = GetNumber("Enter the starting verse: ", 1);

        int endVerse = GetNumber("Enter the ending verse (or enter 0 for one verse): ", 0);

        string text = GetRequiredText("Enter the scripture text: ");

        Reference reference;

        if (endVerse == 0)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }

        return new Scripture(reference, text);
    }
    
    static string GetRequiredText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string text = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            Console.WriteLine("This field cannot be blank.");
        }
    }
    
    static int GetMenuSelection(int maximum)
    {
        while (true)
        {
            try
            {
                int selection = Convert.ToInt32(Console.ReadLine());

                if (selection < 1 || selection > maximum)
                {
                    Console.WriteLine(
                        $"Please enter a number from 1 to {maximum}.");
                    continue;
                }

                return selection;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a whole number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("That number is too large.");
            }
        }
    }
    
    static int GetNumber(string prompt, int minimum)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                int number = Convert.ToInt32(Console.ReadLine());

                if (number < minimum)
                {
                    Console.WriteLine(
                        $"Please enter a number that is at least {minimum}.");
                    continue;
                }

                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a whole number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("That number is too large.");
            }
        }
    }
    static void Main(string[] args)
    {
        Scripture[] scriptures = CreateScriptures();

        Console.WriteLine("Which scripture would you like to memorize?");

        for (int i = 0; i < scriptures.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
        }
        Console.WriteLine($"{scriptures.Length + 1}. Enter your own scripture");
      
        int userSelection;
        userSelection = GetMenuSelection(scriptures.Length + 1);

        Scripture scripture;
        if (userSelection == scriptures.Length + 1)
        {
            scripture = CreateCustomScripture();
        }
        else
        {
            scripture = scriptures[userSelection - 1];
        }
        Console.Clear();
        Console.WriteLine("Here is your scripture:");
        Console.WriteLine(scripture);
        while (!scripture.IsCompletelyHidden())
        {
            

            Console.Write("Press Enter to continue or type quit: ");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                Console.WriteLine("Exiting...");
                return;
            }

            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture);
            
        }
        
        Console.WriteLine("Good work! You now have the scripture memorized.");
    }
    
    
}