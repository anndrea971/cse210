using System;

// Represents a "bad habit" or action that costs points.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty) 
    {

    }

    public NegativeGoal(string name, string description, int penalty, string extraData = "")
        : base(name, description, penalty)
    {

    }

   
    public override int RecordEvent()
    {
        int pointsLost = _points * -1; 
        Console.WriteLine($"\nOuch. You failed the Negative Goal '{GetShortName()}' and lost {_points} points!");
        return pointsLost;
    }

    public override bool IsComplete()
    {
        return false;
    }

    // Override GetDetailsString 
    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({_description}) - Penalty: {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetShortName()}:{_description}:{_points}";
    }
}