using System;
using System.Collections.Generic;
using System.Linq;

public class ListingActivity : Activity
{
    protected List<string> _prompts; 
    private Random _random;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override void DoActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");

        Console.Write("You may begin in: ");
        ShowCountdown(5); // Countdown before starting

        Console.WriteLine("\nStart listing items now (press Enter after each item):");
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int itemCount = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine(); 
            
            // Check for time after each item is entered
            if (DateTime.Now < endTime)
            {
                itemCount++;
            }
        }

        Console.WriteLine($"\nTime's up! You listed {itemCount} items.");
    }

    protected string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}