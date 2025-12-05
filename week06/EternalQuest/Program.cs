using System;

/*
Project: Eternal Quest Program
Exceeding Requirements:
Negative Goal (`NegativeGoal.cs`):
 * - A new derived class, `NegativeGoal`, was created to track bad habits.
 * - Recording a Negative Goal results in a **loss of points** (penalty).
 */

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string choice = "";

        // Main Menu Loop
        do
        {
            Console.Clear();
            manager.DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalDetails();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "3":
                    manager.RecordEvent();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "4":
                    manager.SaveGoals();
                    break;
                case "5":
                    manager.LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("\nThank you for working on your Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }

        } while (choice != "6");
    }
}