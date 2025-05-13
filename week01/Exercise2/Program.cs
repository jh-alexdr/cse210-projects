using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
            if (grade < 93) sign = "-";
        }
        else if (grade >= 80)
        {
            letter = "B";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else if (grade >= 70)
        {
            letter = "C";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else if (grade >= 60)
        {
            letter = "D";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else
        {
            letter = "F";
        }

        // Handle special cases for A+ and F+ or F-
        if (letter == "A" && sign == "+") sign = "";
        if (letter == "F") sign = "";

        // Display the letter grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the user passed the course
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}