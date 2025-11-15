using System;
using System.Collections.Generic;
using System.Linq;


public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        
        _words = new List<Word>();
        
        
        string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    
    public void HideRandomWords(int numberToHide)
    {
        
        List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();

        
        if (unhiddenWords.Count == 0)
        {
            return;
        }

        
        int actualWordsToHide = Math.Min(numberToHide, unhiddenWords.Count);

        for (int i = 0; i < actualWordsToHide; i++)
        {
            
            int index = _random.Next(unhiddenWords.Count);
            Word wordToHide = unhiddenWords[index];
            
            
            wordToHide.Hide();
            
            
            unhiddenWords.RemoveAt(index);
        }
    }

    
    public string GetDisplayText()
    {
        
        string scriptureDisplay = $"*** {_reference.GetDisplayText()} ***\n\n";

        
        foreach (Word word in _words)
        {
            scriptureDisplay += word.GetDisplayText() + " ";
        }

        return scriptureDisplay.Trim();
    }

    
    
    public bool IsCompletelyHidden()
    {
        
        return !_words.Any(w => !w.IsHidden());
    }
}