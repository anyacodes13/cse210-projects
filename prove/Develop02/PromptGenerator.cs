namespace Develop02;

public class PromptGenerator
{
   private List<string> _prompts = new List<string>()
   {
      "Who was the most interesting person I interacted with today?",
      "What was the best part of my day?",
      "How did I see the hand of the Lord in my life today?",
      "What was the strongest emotion I felt today?",
      "If I had one thing I could do over today, what would it be?",
      "What are you grateful for today?",
      "How did I feel the Spirit today?",
   };
      
   private Random _randomGenerator = new Random();
   
   public string GetPrompt()
   {
      
      int randomIndex = _randomGenerator.Next(_prompts.Count);

      string randomPrompt = _prompts[randomIndex];

      return randomPrompt;
   }
}