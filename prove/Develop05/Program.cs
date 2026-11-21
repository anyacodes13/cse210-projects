using System;
using Develop05;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.UserInput();
    }
}

// For my stretch challenge, I added a goal suggestions feature to the program. I created a new `GoalSuggestions` class that displays ten example goals, including simple, eternal, and checklist goals. The user can choose one of the suggestions, and the selected goal is added to the existing goal list. This feature makes the program more helpful by giving users ideas when they are unsure what goals to create.