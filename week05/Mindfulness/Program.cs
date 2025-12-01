/*
 * Exceeding Requirements: Gratitude Journaling Activity, which extends ListingActivity. and Implemented a log file (`activity_log.txt`) to track the number of times each activity was performed,
 * demonstrating saving and loading a log file. 
*/

using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        
        Activity.LoadLog();
        
        string choice = "";
        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("🌟 Welcome to the Mindfulness Program 🌟");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Start Gratitude Journaling Activity (Exceeding Requirement)");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    // Exceeding Requirement: Gratitude Journaling Activity
                    activity = new GratitudeJournalingActivity();
                    break;
                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. See you next time!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please select a number from 1 to 5.");
                    Activity.ShowSpinner(3);
                    break;
            }

            if (activity != null)
            {
                activity.RunActivity();
            }
        }
        
        Activity.SaveLog();
    }
}

class GratitudeJournalingActivity : ListingActivity
{
    public GratitudeJournalingActivity()
    {
        _name = "Gratitude Journaling Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list things you are grateful for today.";
        _prompts = new List<string>
        {
            "List 5 things you are grateful for right now.",
            "List three simple joys you experienced today.",
            "List people who have positively impacted your life recently.",
            "List three things about yourself you are proud of.",
            "List three things in nature that you appreciate."
        };
    }
}
