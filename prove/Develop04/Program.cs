using System;
using Develop04;

class Program
{
    static void Main(string[] args)
    {
        // Set the menu text color.
        Console.ForegroundColor = ConsoleColor.White;

        // Keep showing the menu until the user quits.
        bool showMenu = true;

        while (showMenu)
        {
            // Display the activity choices.
            Console.WriteLine(
                "Menu Options:\n" +
                "1. Start Breathing Activity\n" +
                "2. Start Reflecting Activity\n" +
                "3. Start Listing Activity\n" +
                "4. Quit"
            );

            Console.WriteLine("Select an option:");

            // Run the activity that matches the user's choice.
            switch (Console.ReadLine())
            {
                case "1":
                    // Create and start the breathing activity.
                    BreathingActivity breathingActivity =
                        new BreathingActivity(
                            "breathing activity",
                            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
                        );

                    breathingActivity.Display();
                    break;

                case "2":
                    // Create and start the reflecting activity.
                    ReflectingActivity reflectingActivity =
                        new ReflectingActivity(
                            "reflecting activity",
                            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
                        );

                    reflectingActivity.Display();
                    break;

                case "3":
                    // Create and start the listing activity.
                    ListingActivity listingActivity =
                        new ListingActivity(
                            "listing activity",
                            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
                        );

                    listingActivity.Display();
                    break;

                case "4":
                    // Show a goodbye message and leave the menu loop.
                    string message = "Exiting...";
                    TypeText(message, 70);

                    Thread.Sleep(1000);
                    showMenu = false;
                    break;

                default:
                    // Handle menu choices that are not valid.
                    Console.WriteLine(
                        "Invalid option. Press any key to try again..."
                    );

                    Console.ReadKey();
                    break;
            }
        }
    }

    // Displays text one character at a time.
    static void TypeText(string text, int delay)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }
}

// For the stretch challenge, I went beyond the basic requirements by adding several extra features to make my mindfulness program more interactive and polished. I added an animated RGB color fades during the breathing activity, and extra validation to require a minimum activity duration. I also added many reflection and listing prompts, made sure reflection questions do not repeat until the list is used, and added an average entries-per-second statistic to the listing activity. These additions helped me practice more advanced programming concepts while making the program more engaging for the user.