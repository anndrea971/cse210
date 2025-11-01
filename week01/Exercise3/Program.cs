using System;

public class GuessMyNumber
{
    public static void Main(string[] args)
    {
        bool playAgain = true;
        
        Random randomGenerator = new Random();

        Console.WriteLine("What is the magic number?");
        Console.WriteLine("Pick a number between 1 and 100, try to guess.");

        do
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("\nWhat is your guess? ");
                string guessText = Console.ReadLine();
                
                if (!int.TryParse(guessText, out guess))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    continue;
                }
                
                guessCount++; 

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses to find the magic number: {magicNumber}.");

            Console.Write("\nDo you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            playAgain = (response == "yes" || response == "y");

        } while (playAgain);

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
