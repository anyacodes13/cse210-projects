namespace Develop04;

public class Activity
{
    // Store the activity's name and description.
    private string _activityName;
    private string _activityDescription;

    // Child activities can use the selected duration.
    protected int _activityDuration;

    public Activity(string activityName, string activityDescription)
    {
        _activityName = activityName;
        _activityDescription = activityDescription;
        _activityDuration = 0;
    }

    // Pause for the requested number of seconds.
    public void Pause(int pauseLength)
    {
        Thread.Sleep(pauseLength * 1000);
    }

    // Start the shared activity setup.
    public void StartActivity()
    {
        DisplayStartMessage();
        _activityDuration = PromptForDuration();
        DisplayDuration();

        // Show a short loading animation.
        ShowSpinner(3);
    }

    // Display the activity introduction.
    public void DisplayStartMessage()
    {
        TypeText($"Welcome to a {_activityName}!", 20);
        Console.WriteLine(_activityDescription);
    }

    // Tell the user the activity is finished.
    public void DisplayFinishedMessage()
    {
        TypeText(
            $"You have completed a {_activityDuration} second {_activityName}."
        );

        Pause(1);

        TypeText("Press Enter to return to the main menu.");
        Console.ReadLine();
    }

    // Ask the user how long the activity should last.
    public int PromptForDuration()
    {
        Console.WriteLine(
            "For how many seconds would you like to do the activity? " +
            "(minimum 20 seconds)"
        );

        int durationOfActivity;

        while (
            !int.TryParse(Console.ReadLine(), out durationOfActivity) ||
            durationOfActivity < 20
        )
        {
            Console.WriteLine(
                "Invalid input. Please enter an integer of at least 20."
            );

            Console.WriteLine(
                "For how many seconds would you like to do the activity?"
            );
        }

        return durationOfActivity;
    }

    // Display the selected activity duration.
    public void DisplayDuration()
    {
        Console.WriteLine(
            $"Your activity will run for {_activityDuration} seconds."
        );
    }

    // Wait for the full activity duration.
    public void Timer()
    {
        for (int i = 0; i < _activityDuration; i++)
        {
            Pause(1);
        }
    }

    // Display text one character at a time.
    public void TypeText(string text, int delay = 70)
    {
        Console.WriteLine();

        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    // Display a simple countdown.
    public void CountDown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }

    // Display a spinning loading animation.
    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        // Hide the cursor while the spinner is running.
        Console.CursorVisible = false;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{frames[frameIndex]}");
            Thread.Sleep(100);

            // Move to the next spinner character.
            frameIndex = (frameIndex + 1) % frames.Length;
        }

        // Clear the spinner and show the cursor again.
        Console.Write("\r ");
        Console.CursorVisible = true;
    }
}