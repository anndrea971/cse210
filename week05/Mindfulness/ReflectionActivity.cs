using System;
using System.Collections.Generic;
using System.Linq; 

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    protected override void DoActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have thought about this experience, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5); // Countdown before starting questions

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

   
        List<string> usedQuestions = new List<string>();

        while (DateTime.Now < endTime)
        {
    
            if (usedQuestions.Count == _questions.Count)
            {
                usedQuestions.Clear();
            }

            string question = GetRandomQuestion(usedQuestions);
            Console.Write($"\n> {question} ");
            
          
            ShowSpinner(8); 
            
            
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion(List<string> used)
    {
        string question;
        do
        {
            question = _questions[_random.Next(_questions.Count)];
        } 
        while (used.Contains(question)); 
        
        used.Add(question);
        return question;
    }
}