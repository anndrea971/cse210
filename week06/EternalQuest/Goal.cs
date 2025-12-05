using System;

public abstract class Goal
{

    protected string _shortName;
    protected string _description; 
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

    public string GetShortName()
    {
        return _shortName;
    }
    
    public string GetDescription()
    {
        return _description;
    }
    
    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} ({GetDescription()})"; 
    }

    public abstract string GetStringRepresentation();
}