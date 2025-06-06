using System;
using System.IO;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you express gratitude by writing a short letter to someone you appreciate. Expressing gratitude can boost your mood and strengthen relationships.")
    { }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\nThink of someone you are grateful for. Who is it?");
        Console.Write("Enter their name: ");
        string name = Console.ReadLine();

        Console.WriteLine($"\nNow, write a short gratitude letter to {name}.");
        Console.WriteLine("Type your letter below. When finished, type 'END' on a new line.");
        string letter = "";
        string line;
        while ((line = Console.ReadLine()) != null && line.ToUpper() != "END")
        {
            letter += line + Environment.NewLine;
        }

        string filename = $"GratitudeLetter_{name}_{DateTime.Now:yyyyMMddHHmmss}.txt";
        File.WriteAllText(filename, letter);

        Console.WriteLine($"\nThank you for expressing your gratitude! Your letter has been saved as '{filename}'.");
        DisplayEndingMessage();
    }
}