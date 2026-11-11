namespace Develop04;

public class ReflectingActivity : Activity
{
    // Store the main reflection prompts.
    private List<string> _questions = new List<string>();

    // Store the follow-up questions.
    private List<string> _followUpQuestions = new List<string>();

    public ReflectingActivity(
        string activityName,
        string activityDescription
    ) : base(activityName, activityDescription)
    {
        // Add the main reflection prompts.
        _questions.Add("Think of a time when you stood up for someone else.");
        _questions.Add("Think of a time when you did something really difficult.");
        _questions.Add("Think of a time when you helped someone in need.");
        _questions.Add("Think of a time when you did something truly selfless.");
        _questions.Add("Think of a time when someone helped you.");
        _questions.Add("Think of a time when you showed courage.");
        _questions.Add("Think of a time when you learned from a mistake.");
        _questions.Add("Think of a time when you forgave someone.");
        _questions.Add("Think of a time when you had to be patient.");
        _questions.Add("Think of a time when you encouraged someone.");
        _questions.Add("Think of a time when you overcame a fear.");
        _questions.Add("Think of a time when you made a sacrifice for someone else.");
        _questions.Add("Think of a time when you were proud of yourself.");
        _questions.Add("Think of a time when you showed kindness to a stranger.");
        _questions.Add("Think of a time when you worked hard to accomplish a goal.");
        _questions.Add("Think of a time when you had to make a difficult decision.");
        _questions.Add("Think of a time when you learned something important about yourself.");
        _questions.Add("Think of a time when you made someone feel included.");
        _questions.Add("Think of a time when you remained positive during a difficult situation.");

        // Add the follow-up questions.
        _followUpQuestions.Add("Why was this experience meaningful to you?");
        _followUpQuestions.Add("Have you ever done anything like this before?");
        _followUpQuestions.Add("How did you get started?");
        _followUpQuestions.Add("How did you feel when it was complete?");
        _followUpQuestions.Add("What made this time different than other times when you were not as successful?");
        _followUpQuestions.Add("What is your favorite thing about this experience?");
        _followUpQuestions.Add("What could you learn from this experience that applies to other situations?");
        _followUpQuestions.Add("What did you learn about yourself through this experience?");
        _followUpQuestions.Add("How can you keep this experience in mind in the future?");
        _followUpQuestions.Add("What challenges did you face during this experience?");
        _followUpQuestions.Add("How did you overcome the challenges you faced?");
        _followUpQuestions.Add("Did anyone support or encourage you during this experience?");
        _followUpQuestions.Add("How did this experience change the way you think?");
        _followUpQuestions.Add("What would you do differently if you experienced this again?");
        _followUpQuestions.Add("What advice would you give someone in a similar situation?");
        _followUpQuestions.Add("What strengths did you use during this experience?");
        _followUpQuestions.Add("How did this experience affect your relationship with others?");
        _followUpQuestions.Add("What was the most memorable part of this experience?");
        _followUpQuestions.Add("What did this experience teach you about making difficult choices?");
    }

    // Run the complete reflecting activity.
    public void Display()
    {
        StartActivity();
        DisplayQuestion();
        DisplayFinishedMessage();
    }

    // Display the main prompt and cycle through follow-up questions.
    public void DisplayQuestion()
    {
        // Choose a random main reflection prompt.
        int index = Random.Shared.Next(_questions.Count);
        string randomQuestion = _questions[index];

        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {randomQuestion} ---");
        Console.WriteLine("When you have something in mind, press Enter.");

        // Wait for the user to think of an experience.
        Console.ReadLine();

        Console.WriteLine(
            "Now ponder how each of the following questions relates to what you thought about. " +
            "No need to write, just think. Press Enter to see the next prompt."
        );

        // Give the user a short countdown.
        CountDown(5);
        Console.Clear();

        // Copy the questions so they can be removed without changing the original list.
        List<string> availableQuestions =
            new List<string>(_followUpQuestions);

        DateTime startTime = DateTime.Now;

        // Continue asking questions until the activity time ends.
        while (
            (DateTime.Now - startTime).TotalSeconds < _activityDuration
        )
        {
            // Start a new question cycle when all questions have been used.
            if (availableQuestions.Count == 0)
            {
                availableQuestions =
                    new List<string>(_followUpQuestions);
            }

            // Choose and display a random unused question.
            int i = Random.Shared.Next(availableQuestions.Count);
            string randomPrompt = availableQuestions[i];

            Console.WriteLine(randomPrompt);
            Console.ReadLine();

            // Remove the question so it is not repeated in this cycle.
            availableQuestions.Remove(randomPrompt);
        }
    }
}