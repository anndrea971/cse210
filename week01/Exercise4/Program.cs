using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");

            string userResponse = Console.ReadLine();
            try
            {
                userNumber = int.Parse(userResponse);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        
        Console.WriteLine($"The average is: {average:G}");

        int max = 0;
        if (numbers.Count > 0)
        {
            max = numbers.Max();
        }
        
        Console.WriteLine($"The largest number is: {max}");

        int smallestPositive = -1;

        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();

        if (positiveNumbers.Count > 0)
        {
            smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        if (numbers.Count > 0)
        {
            numbers.Sort();

            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}