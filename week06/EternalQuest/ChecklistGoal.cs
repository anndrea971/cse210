using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;


    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            int pointsEarned = _points;

            if (IsComplete())
            {
                pointsEarned += _bonus;
                Console.WriteLine($"\n*** CONGRATULATIONS! *** You have completed the Checklist Goal '{GetShortName()}' and earned a bonus of {_bonus} points!");
            }
            
            return pointsEarned;
        }
    
        return 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string baseDetails = base.GetDetailsString();
        return $"{baseDetails} -- Currently completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}:{_description}:{_points}:{_bonus}:{_target}:{_amountCompleted}";
    }
}