using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    
    }

    public EternalGoal(string name, string description, int points, string extraData = "")
        : base(name, description, points)
    {
        
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"\nWell done! You have recorded the Eternal Goal '{GetShortName()}' and earned {_points} points!");
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()}:{_description}:{_points}";
    }
}