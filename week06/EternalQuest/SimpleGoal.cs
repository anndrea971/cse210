using System;

public class SimpleGoal : Goal
{
    private bool _isComplete; // Atributo privado

    // Constructor para crear un nuevo goal
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor para cargar un goal desde archivo
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
            // Usa _points (protected) y GetShortName() (public)
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

    // Guarda el estado de los campos protegidos y el campo privado
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}:{_description}:{_points}:{_isComplete}";
    }
}