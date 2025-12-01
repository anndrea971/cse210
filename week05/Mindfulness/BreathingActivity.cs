using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void DoActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
           
            Console.Write("\nBreathe in...");
            ShowCountdown(4);

            if (DateTime.Now >= endTime) break; 

            
            Console.Write("Breathe out...");
           
            int breathOutTime = 6; 
            if ((endTime - DateTime.Now).TotalSeconds < breathOutTime)
            {
                breathOutTime = (int)(endTime - DateTime.Now).TotalSeconds;
            }

            if (breathOutTime > 0)
            {
                ShowCountdown(breathOutTime);
            }
            
        }
    }
}