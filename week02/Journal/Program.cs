using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Main application class for the Journal Program.
public class Program
{
    // === EXCESS REQUIREMENTS/CREATIVITY ===
    // 1. Used a more complex, less likely-to-be-used separator (~~~).
    // 2. Added error handling (try-catch blocks) in the Journal class for file operations 
    //    to gracefully handle exceptions like FileNotFoundException.
    // 3. Implemented a better check in the LoadFromFile method to handle responses 
    //    that might unintentionally contain the '~~~' separator (though simplified).
    // ======================================

    // Member variables for abstraction
    private Journal _journal = new Journal();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Describe a moment where you felt grateful today.", // Added custom prompt
        "What is one small, good thing you did for someone else today?" // Added custom prompt
    };

    // Main entry point
    public static void Main(string[] args)
    {
        Program program = new Program();
        program.RunMenu();
    }

    // Displays the menu and processes user input
    private void RunMenu()
    {
        string choice = "";
        
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    DoNewEntry();
                    break;
                case "2":
                    _journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the filename to load from (e.g., myjournal.txt): ");
                    string loadFile = Console.ReadLine() ?? "";
                    _journal.LoadFromFile(loadFile);
                    break;
                case "4":
                    Console.Write("Enter the filename to save to (e.g., myjournal.txt): ");
                    string saveFile = Console.ReadLine() ?? "";
                    _journal.SaveToFile(saveFile);
                    break;
                case "5":
                    Console.WriteLine("\nThank you for journaling! Goodbye.");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    // Gets a random prompt and the user's response, then creates an entry
    private void DoNewEntry()
    {
        // 1. Get a random prompt
        string prompt = GetRandomPrompt();
        
        // 2. Get the current date as a string
        string date = DateTime.Now.ToShortDateString();
        
        // 3. Display the prompt and get user response
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine() ?? "";

        // 4. Create a new Entry object and add it to the Journal
        Entry newEntry = new Entry(date, prompt, response);
        _journal.AddEntry(newEntry);
        
        Console.WriteLine("Entry saved successfully.");
    }

    // Selects a random prompt from the list
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}