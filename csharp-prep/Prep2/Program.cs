using System;

class Program
{
    static void Main(string[] args)
    {
        // Asking the user fore their grade
        Console.WriteLine("What is you grade in this class?");
        int grade = 
        int.Parse(Console.ReadLine());
        string letter = "";

        // Print in the console the grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");

        // Print if the user is passing 
        if (grade >= 70)
        {
            Console.WriteLine("You are passing the class. Congrats!!");
        }

        else
        {
            Console.WriteLine("You did not pass. Try again! You got this!");
        }




    }
}