using System;
using System.Net;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // Setting up the while loop to play again
        bool again = false;
        do{
            // Set up the number
            bool correct = false;
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);
            Console.WriteLine("Here we go!");

            // Loop for the guesses
            do {
        
            Console.WriteLine(" What is your guess?");
            int input = int.Parse(Console.ReadLine());
            

                if (input < number)
                {
                    Console.WriteLine("Higher");
                }

                else if (input > number)
                {
                    Console.WriteLine("Lower");
                }

                else
                {
                    Console.WriteLine("That is Correct!");
                    correct = true;
                }

            } while (correct == false);

            // asking if the user would like to play again
            Console.WriteLine(" Would you like to play again? (y/n)");
            string response = (Console.ReadLine());
            if (response == "y")
            {
                again = true;
            }
        } while (again == true);
        
    }
}