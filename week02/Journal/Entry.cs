using System;

// Represents a single journal entry.
public class Entry
{
    // Member variables for abstraction
    private string _date;
    private string _promptText;
    private string _entryText;

    // Constructor to initialize an entry
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    // Method to display the entry to the console
    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"> {_entryText}");
    }

    // Method to format the entry for saving to a file.
    // We use "~~~" as the separator.
    public string ToSaveString()
    {
        // Format: Date~~~Prompt Text~~~Response Text
        return $"{_date}~~~{_promptText}~~~{_entryText}";
    }
}