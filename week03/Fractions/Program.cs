using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        // Test constructors
        Fraction f1 = new Fraction();         // 1/1
        Fraction f2 = new Fraction(5);        // 5/1
        Fraction f3 = new Fraction(3, 4);     // 3/4
        Fraction f4 = new Fraction(1, 3);     // 1/3

        // Display fractions and decimal values
        Console.WriteLine(f1.GetFractionString() + " = " + f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString() + " = " + f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString() + " = " + f3.GetDecimalValue());
        Console.WriteLine(f4.GetFractionString() + " = " + f4.GetDecimalValue());

        // Test getters and setters
        f1.SetTop(6);
        f1.SetBottom(7);
        Console.WriteLine("Changed f1: " + f1.GetFractionString() + " = " + f1.GetDecimalValue());
        Console.WriteLine("Top: " + f1.GetTop() + ", Bottom: " + f1.GetBottom());
    }
}