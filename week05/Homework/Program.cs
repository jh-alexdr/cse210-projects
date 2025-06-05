using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Assignment base class
        Assignment assignment = new Assignment("Jhon Tobar", "Geometry");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        // Test MathAssignment
        MathAssignment math = new MathAssignment("Evelin Guillen", "Algebra", "5.2", "12-18, 22");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();

        // Test WritingAssignment
        WritingAssignment writing = new WritingAssignment("Rosa Santamaria", "World Literature", "The Power of Storytelling");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}