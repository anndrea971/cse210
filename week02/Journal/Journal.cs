using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string Separator = "~~~"; 

    
    public void AddEntry(Entry newEntry) 
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll() 
    {
        
    }

    public void SaveToFile(string filename) 
    {
    
    }

    public void LoadFromFile(string filename) 
    {
        
    }
}