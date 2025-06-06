using System;

// Exceeds requirements: Added a "Gratitude Activity" that guides the user to write a gratitude letter to someone. 
// This creative feature encourages positive reflection and can be saved to a file for later use.

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity"); // Added creative activity
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
            else if (choice == "4")
            {
                new GratitudeActivity().Run(); // Call the new activity
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}