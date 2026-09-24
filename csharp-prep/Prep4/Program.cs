using System;
using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers;
        numbers = new List<int>();
        int userInput = -1;
        Console.WriteLine("Enter a list of numbers (positive or negative), type 0 when finished.");
        while (userInput != 0)
        {
        
            Console.WriteLine("Enter a number:");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0) {
                numbers.Add(userInput);
            }
    
        }
        // Calculating the Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        int smallest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > 0){
                if (number > smallest)
                {
                    smallest = number;
                }
            }
        }

        Console.WriteLine($"The smallest positive number is: {smallest}");
   
    }
}