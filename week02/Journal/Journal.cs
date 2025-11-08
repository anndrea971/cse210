using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string Separator = "~~~"; 

    // ESTOS MÉTODOS DEBEN SER PÚBLICOS
    public void AddEntry(Entry newEntry) // <-- Debe ser public
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll() // <-- Debe ser public y con D mayúscula
    {
        // ... Lógica para mostrar las entradas
    }

    public void SaveToFile(string filename) // <-- Debe ser public y con S mayúscula
    {
        // ... Lógica para guardar
    }

    public void LoadFromFile(string filename) // <-- Debe ser public y con L mayúscula
    {
        // ... Lógica para cargar
    }
}