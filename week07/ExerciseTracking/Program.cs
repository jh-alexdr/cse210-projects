using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 06, 16), 30, 4.8),
            new Cycling(new DateTime(2025, 06, 16), 45, 15.0),
            new Swimming(new DateTime(2025, 06, 16), 40, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}