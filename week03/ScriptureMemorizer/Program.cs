//This program is an OOP Scripture Memorizer that displays a randomly selected scripture from a library, hiding several previously unhidden words with underscores upon each user interaction until the text is fully concealed or the user quits.
using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main(string[] args)
    {
        
        List<Scripture> scriptureLibrary = InitializeScriptureLibrary();

        
        Random random = new Random();
        int index = random.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[index];

        string userInput = "";

        
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\n------------------------------------------------------------");

            
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Program ending.");
                break; 
            }

            
            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            userInput = Console.ReadLine()?.Trim() ?? "";

            if (userInput.ToLower() != "quit")
            {
                
                scripture.HideRandomWords(3);
            }
        }

        
        if (userInput.ToLower() == "quit")
        {
             Console.Clear();
             Console.WriteLine(scripture.GetDisplayText());
             Console.WriteLine("\n------------------------------------------------------------");
             Console.WriteLine("Program ended by user.");
        }
        
        
        Console.WriteLine("\nPress any key to close the application...");
        Console.ReadKey();
    }

    
    private static List<Scripture> InitializeScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        
        Reference ref1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        library.Add(new Scripture(ref1, text1));

        
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        library.Add(new Scripture(ref2, text2));
        
        
                Reference ref3 = new Reference("Alma", 37, 35);
                string text3 = "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God.";
                library.Add(new Scripture(ref3, text3));
        
                return library;
            }
        }