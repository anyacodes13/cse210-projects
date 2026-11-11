namespace Develop04;

public class ListingActivity : Activity
{
    // Store the prompts the user can choose from.
    private List<string> _listingPrompts = new List<string>();

    // Store each response entered by the user.
    private List<string> _entries = new List<string>();

    // Create the listing activity and add its prompts.
    public ListingActivity(
        string activityName,
        string activityDescription
    ) : base(activityName, activityDescription)
    {
        // Add prompts for the listing activity.
        _listingPrompts.Add("What are personal strengths of yours?");
        _listingPrompts.Add("Who are people that you have helped this week?");
        _listingPrompts.Add("When have you felt the Holy Ghost this month?");
        _listingPrompts.Add("Who are some of your personal heroes?");
        _listingPrompts.Add("What is something you are grateful for today?");
        _listingPrompts.Add("What is a goal you are currently working toward?");
        _listingPrompts.Add("What is something kind someone has done for you?");
        _listingPrompts.Add("What is one way you have grown recently?");
        _listingPrompts.Add("What is something that brings you peace?");
        _listingPrompts.Add("What is a talent or skill you would like to improve?");
        _listingPrompts.Add("What is one good decision you made recently?");
        _listingPrompts.Add("What is something you enjoy doing with your family?");
        _listingPrompts.Add("What is one challenge you are currently overcoming?");
        _listingPrompts.Add("What is a positive quality you admire in others?");
    }

    // Run the complete listing activity.
    public void Display()
    {
        StartActivity();
        PromptUser();

        // Display the total number of responses.
        Console.WriteLine($"You have written {_entries.Count} entries.");

        // Display the average number of entries per second.
        Console.WriteLine(
            $"That is an average of {(double)_entries.Count / _activityDuration} entries per second."
        );

        DisplayFinishedMessage();
    }

    // Display a prompt and collect the user's responses.
    public void PromptUser()
    {
        // Choose a random prompt from the list.
        int index = Random.Shared.Next(_listingPrompts.Count);
        string randomPrompt = _listingPrompts[index];

        Console.Clear();
        Console.WriteLine(
            "List as many responses you can think of for the following prompt."
        );
        Console.WriteLine($"--- {randomPrompt} ---");
        Console.WriteLine("Get Ready");

        // Give the user time to prepare.
        CountDown(5);

        // Record when the listing activity begins.
        DateTime startTime = DateTime.Now;

        // Continue collecting responses until the time runs out.
        while (
            (DateTime.Now - startTime).TotalSeconds < _activityDuration
        )
        {
            Console.WriteLine();
            Console.Write(">");

            // Read and save the user's response.
            string userEntry = Console.ReadLine();
            _entries.Add(userEntry);
        }
    }
}