using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        
        int birthYear;
        PromptUserBirthYear(out birthYear);
        
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber, birthYear);
    
    
        static void DisplayWelcome ()
        {
            Console.WriteLine("Welcome to the Program!");
        } 
        
        static string PromptUserName ()
        {
            Console.WriteLine("What is your name?");
            string name = (Console.ReadLine());
            return name;
        } 

        static int PromptUserNumber ()
        {
            Console.WriteLine("What is your favorite number?");
            int number = int.Parse(Console.ReadLine());
            return number;
        } 

        static void PromptUserBirthYear(out int birthYear)
        {
        Console.WriteLine("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
        }
        
        static int SquareNumber ( int number)
        {
            int square = number * number;
            return square;
        }
        
        static void DisplayResult(string name, int square, int birthYear)
        {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2026 - birthYear} years old this year.");
        }
    }
}


//DisplayWelcome - Displays the message, "Welcome to the Program!"
// PromptUserName - Asks for and returns the user's name (as a string)
// PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
// PromtUserBirthYear - Accepts out integer parameter and prompts the user for the year they were born. The out parameter is set to their birth year. This function does not return a value. The user's birth year is given back from the function via the out parameter.
// SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
// DisplayResult - Accepts the user's name, the squared number, and the user's birth year. Display the user's name and squared number. Calculate hold many years old they will turn this year and display that.