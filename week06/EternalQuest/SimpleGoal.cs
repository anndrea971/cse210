using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"\nCongratulations! You have completed the Simple Goal '{GetShortName()}' and earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine($"\nNote: The Simple Goal '{GetShortName()}' is already completed.");
            return 0; 
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetShortName()}:{_description}:{_points}:{_isComplete}";
    }
}