using System;

public class EternalGoal : Goal
{
    // Constructor para crear un nuevo goal
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Constructor para cargar un goal desde archivo
    public EternalGoal(string name, string description, int points, string extraData = "")
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Usa _points (protected) y GetShortName() (public)
        Console.WriteLine($"\nWell done! You have recorded the Eternal Goal '{GetShortName()}' and earned {_points} points!");
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({_description})"; // Acceso a _description (protected)
    }

    // Guarda el estado de los campos protegidos
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}:{_description}:{_points}";
    }
}