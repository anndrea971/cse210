using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();
    private const string LogFileName = "activity_log.txt";
    public Activity()
    {
        _name = "Generic Activity";
        _description = "A standard mindfulness activity.";
        _duration = 0;
    }
    public void RunActivity()
    {
        DisplayStartingMessage();
        
        DoActivity();

        DisplayEndingMessage();
        
        if (_activityLog.ContainsKey(_name))
        {
            _activityLog[_name]++;
        }
        else
        {
            _activityLog.Add(_name, 1);
        }
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine($"{_description}");
        
        if (_activityLog.ContainsKey(_name))
        {
            Console.WriteLine($"(You have completed this activity {_activityLog[_name]} time(s) before.)");
        }
        
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int duration) && duration > 0)
        {
            _duration = duration;
        }
        else
        {
            _duration = 30; 
            Console.WriteLine($"Invalid input, defaulting to {_duration} seconds.");
        }

        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); 
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3); 

        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(4); 
    }

    protected abstract void DoActivity();

    public static void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animation[i];
            Console.Write(s);
            Thread.Sleep(250); // Pause for 250ms
            Console.Write("\b \b"); // Overwrite the character
            i = (i + 1) % animation.Count;
        }
        Console.WriteLine(); // New line after spinner finishes
    }

    // Shared behavior: Displays a countdown timer while pausing
    public static void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Use Console.Write to stay on the same line
            Console.Write($"{i}"); 
            Thread.Sleep(1000); // Wait for 1 second
            
            // Overwrite the number by writing spaces and moving the cursor back
            string erase = new string('\b', i.ToString().Length) + new string(' ', i.ToString().Length) + new string('\b', i.ToString().Length);
            Console.Write(erase);
        }
    }
    
    // Exceeding Requirement: Save activity log
    public static void SaveLog()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFileName))
            {
                foreach (var entry in _activityLog)
                {
                    writer.WriteLine($"{entry.Key}|{entry.Value}");
                }
            }
            Console.WriteLine($"\nActivity log saved to {LogFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving activity log: {ex.Message}");
        }
    }

    // Exceeding Requirement: Load activity log
    public static void LoadLog()
    {
        if (File.Exists(LogFileName))
        {
            try
            {
                using (StreamReader reader = new StreamReader(LogFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                        {
                            _activityLog[parts[0]] = count;
                        }
                    }
                }
                Console.WriteLine($"Activity log loaded from {LogFileName}");
                ShowSpinner(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading activity log: {ex.Message}");
            }
        }
    }
}