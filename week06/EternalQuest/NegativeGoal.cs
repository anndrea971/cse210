using System;

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

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({GetDescription()}) - Penalty: {GetPoints()} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName}:{_description}:{_points}";
    }
}