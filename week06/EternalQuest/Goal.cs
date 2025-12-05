using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public Goal(string name, string description, int points, string extraData)
        : this(name, description, points)
    {
        
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        
        return $"{status} {_shortName} ({_description})";
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public abstract string GetStringRepresentation();
}