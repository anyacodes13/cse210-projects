namespace Develop05;

using System;

public class GoalSuggestions
{
    public void DisplaySuggestions(GoalList goalList)
    {
        Console.WriteLine("\nGoal Suggestions");

        Console.WriteLine("1. Read for 20 minutes every day");
        Console.WriteLine("2. Drink 8 glasses of water");
        Console.WriteLine("3. Exercise 3 times each week");
        Console.WriteLine("4. Write in a journal");
        Console.WriteLine("5. Read 5 books");
        Console.WriteLine("6. Call a family member each week");
        Console.WriteLine("7. Save money each month");
        Console.WriteLine("8. Learn a new recipe");
        Console.WriteLine("9. Attend church every Sunday");
        Console.WriteLine("10. Practice a musical instrument");

        Console.Write("\nEnter the number of a goal to add it, or 0 to cancel: ");
        string choice = Console.ReadLine() ?? "0";

        switch (choice)
        {
            case "1":
                goalList.AddGoal(
                    new EternalGoal(
                        "Read for 20 minutes every day",
                        10));
                break;

            case "2":
                goalList.AddGoal(
                    new ChecklistGoal(
                        "Drink 8 glasses of water",
                        5,
                        25,
                        7));
                break;

            case "3":
                goalList.AddGoal(
                    new ChecklistGoal(
                        "Exercise 3 times each week",
                        10,
                        50,
                        3));
                break;

            case "4":
                goalList.AddGoal(
                    new EternalGoal(
                        "Write in a journal",
                        10));
                break;

            case "5":
                goalList.AddGoal(
                    new ChecklistGoal(
                        "Read 5 books",
                        25,
                        100,
                        5));
                break;

            case "6":
                goalList.AddGoal(
                    new EternalGoal(
                        "Call a family member each week",
                        10));
                break;

            case "7":
                goalList.AddGoal(
                    new EternalGoal(
                        "Save money each month",
                        20));
                break;

            case "8":
                goalList.AddGoal(
                    new SimpleGoal(
                        "Learn a new recipe",
                        25));
                break;

            case "9":
                goalList.AddGoal(
                    new EternalGoal(
                        "Attend church every Sunday",
                        20));
                break;

            case "10":
                goalList.AddGoal(
                    new EternalGoal(
                        "Practice a musical instrument",
                        15));
                break;

            case "0":
                Console.WriteLine("No goal was added.");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("Goal added successfully.");
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}