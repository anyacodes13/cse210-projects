namespace Develop04;

public class BreathingActivity : Activity
{
    // Use the shared activity name and description.
    public BreathingActivity(
        string activityName,
        string activityDescription
    ) : base(activityName, activityDescription)
    {
    }

    // Run the full breathing activity.
    public void Display()
    {
        StartActivity();
        BreathTimer();
        DisplayFinishedMessage();
    }

    // Control the breathing cycles and ending countdown.
    public void BreathTimer()
    {
        // Run one cycle if the duration is shorter than 16 seconds.
        if (_activityDuration < 16)
        {
            DisplayText();
        }
        else
        {
            // Each complete breathing cycle takes about 16 seconds.
            int breathActivityDuration = _activityDuration / 16;

            // Show a countdown before beginning.
            TypeText("Get Ready! Start in...");
            FadeCountDown(4, 255, 255, 255, 0, 0, 255);

            // Repeat the breathing cycle for the selected duration.
            for (int i = 0; i < breathActivityDuration; i++)
            {
                DisplayText();
            }

            // Show a short countdown before ending.
            TypeText("Ending activity in");
            FadeCountDown(4, 0, 0, 255, 255, 255, 255);
        }
    }

    // Display one complete breathing cycle.
    private void DisplayText()
    {
        string breathIn = "Breath In";
        string breathOut = "Breath Out";
        string hold = "Hold";

        // Start the breathing text in blue.
        SetTextColor(0, 0, 255);
        TypeText(breathIn);

        // Fade from blue to cyan while breathing in.
        FadeCountDown(4, 0, 0, 255, 0, 255, 255);

        // Keep the current color during the hold.
        TypeText(hold);
        CountDown(4);

        TypeText(breathOut);

        // Fade from cyan back to blue while breathing out.
        FadeCountDown(4, 0, 255, 255, 0, 0, 255);

        // Keep the current color during the second hold.
        TypeText(hold);
    }

    // Set the console text color using RGB values.
    public void SetTextColor(int red, int green, int blue)
    {
        Console.Write($"\u001b[38;2;{red};{green};{blue}m");
    }

    // Gradually change the color while counting down.
    public void FadeCountDown(
        int seconds,
        int startRed,
        int startGreen,
        int startBlue,
        int endRed,
        int endGreen,
        int endBlue
    )
    {
        int totalSteps = seconds * 20;

        for (int i = 0; i <= totalSteps; i++)
        {
            // Calculate how far through the fade we are.
            double progress = (double)i / totalSteps;

            // Gradually calculate each RGB value.
            int red =
                (int)(startRed + (endRed - startRed) * progress);

            int green =
                (int)(startGreen + (endGreen - startGreen) * progress);

            int blue =
                (int)(startBlue + (endBlue - startBlue) * progress);

            SetTextColor(red, green, blue);

            // Update the countdown on the same line.
            int remaining = seconds - (i / 20);
            Console.Write($"\b{remaining} ");

            Thread.Sleep(50);
        }
    }
}