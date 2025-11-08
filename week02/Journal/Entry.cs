using System;


public class Entry
{
    
    private string _date;
    private string _promptText;
    private string _entryText;

    
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    
    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }

    
    public string ToSaveString()
    {
    
        return $"{_date}~~~{_promptText}~~~{_entryText}";
    }
}