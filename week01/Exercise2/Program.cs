using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        string sign = "";
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = percent % 10;
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit <= 3)
        {
            sign = "-";
        }

        if (letter == "F")
        {
            sign = "";
        }
        
        if (letter == "A")
        {
            if (sign == "+")
            {
                sign = "";
            }   
        if (percent >= 100)
            {
                sign = "";
            }
        }

        Console.WriteLine($"Your letter grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("You passed! Congratulations!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}