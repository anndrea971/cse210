using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private string _title;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _title = "Novice Pilgrim";
    }

    public void Start()
    {

    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n*** Current Quest Status ***");
        Console.WriteLine($"Level: {_level} - Title: {_title}");
        Console.WriteLine($"You have **{_score}** points.");
        Console.WriteLine("------------------------------");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals currently set. Choose 'Create New Goal' to begin your quest!");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {

            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}"); 
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal (Complete once)");
        Console.WriteLine("  2. Eternal Goal (Repeatable)");
        Console.WriteLine("  3. Checklist Goal (Complete N times)");
        Console.WriteLine("  4. Negative Goal (Habit to avoid - penalty)"); // Exceeding Req.

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        // TryParse is safer than Parse, but for simple user input in this project, Parse is common.
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus amount for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (choice == "4")
        {
             // For NegativeGoal, 'points' is actually the penalty amount
            _goals.Add(new NegativeGoal(name, description, points));
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal creation cancelled.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to record events for.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        Console.Write("Which goal did you accomplish (Enter the number)? ");
        if (int.TryParse(Console.ReadLine(), out int choiceIndex))
        {
            int index = choiceIndex - 1;

            if (index >= 0 && index < _goals.Count)
            {
                // Polymorphism: RecordEvent is called, and the correct derived method executes.
                int pointsEarned = _goals[index].RecordEvent(); 
                _score += pointsEarned;
                CheckLevelUp(); // Check for level up after scoring

                Console.WriteLine($"\nYou now have **{_score}** points.");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        // using block ensures the StreamWriter is properly closed
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // 1. Save Score and Level (Exceeding Requirement)
            outputFile.WriteLine($"Score:{_score},Level:{_level}");

            // 2. Save Goals
            foreach (Goal goal in _goals)
            {
                // Polymorphism: calls the specific GetStringRepresentation() for each goal type
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"\nGoals saved to '{filename}'.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nError: File '{filename}' not found.");
            return;
        }

        // Clear existing goals before loading new ones
        _goals.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        // 1. Load Score and Level from the first line
        if (lines.Length > 0)
        {
            string[] statusParts = lines[0].Split(',');
            
            // Assuming format: Score:X,Level:Y
            if (statusParts.Length >= 2 && statusParts[0].StartsWith("Score:") && statusParts[1].StartsWith("Level:"))
            {
                _score = int.Parse(statusParts[0].Split(':')[1]);
                _level = int.Parse(statusParts[1].Split(':')[1]);
                UpdateTitle(); // Update the title based on the loaded level
            }
        }

        // 2. Load Goals from the rest of the lines
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            // Split by ':' to get the Goal Type and the data string
            string[] parts = line.Split(':', 2); 
            string goalType = parts[0];
            string data = parts[1];

            // Use the type string to create the correct object (Factory Pattern approach)
            Goal newGoal = CreateGoalFromData(goalType, data);
            if (newGoal != null)
            {
                _goals.Add(newGoal);
            }
        }
        Console.WriteLine($"\nGoals loaded from '{filename}'.");
    }

    private Goal CreateGoalFromData(string type, string data)
    {
        string[] fields = data.Split(':');
        string name = fields[0];
        string description = fields[1];
        int points = int.Parse(fields[2]);

        if (type == "SimpleGoal")
        {
            // Data fields: <name>:<description>:<points>:<isComplete>
            bool isComplete = bool.Parse(fields[3]);
            return new SimpleGoal(name, description, points, isComplete);
        }
        else if (type == "EternalGoal")
        {
            // Data fields: <name>:<description>:<points>
            return new EternalGoal(name, description, points);
        }
        else if (type == "ChecklistGoal")
        {
            // Data fields: <name>:<description>:<points>:<bonus>:<target>:<amountCompleted>
            int bonus = int.Parse(fields[3]);
            int target = int.Parse(fields[4]);
            int amountCompleted = int.Parse(fields[5]);
            return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
        }
        else if (type == "NegativeGoal") // Exceeding Req.
        {
            // Data fields: <name>:<description>:<penalty (stored in _points)>
            return new NegativeGoal(name, description, points);
        }

        return null;
    }

    private void CheckLevelUp()
    {
        int requiredScore = (int)(1000 * Math.Pow(_level, 1.5)); 

        if (_score >= requiredScore)
        {
            _level++;
            UpdateTitle();
            Console.WriteLine("\n\n***************************************************");
            Console.WriteLine($"*** QUEST SUCCESS! You have reached Level {_level}! ***");
            Console.WriteLine($"*** New Title: {_title} ***");
            Console.WriteLine("***************************************************");
        }
    }
    
    private void UpdateTitle()
    {

        _title = _level switch
        {
            1 => "Novice Pilgrim",
            2 => "Apprentice Seeker",
            3 => "Evolving Disciple",
            4 => "Focused Guardian",
            5 => "Level 5 Crusader",
            6 => "Adept Champion",
            7 => "Silver Paladin",
            8 => "Golden Saint",
            9 => "Mythic Warlord",
            10 => "Eternal Questor",
            _ => $"Level {_level} Legend"
        };
    }
}