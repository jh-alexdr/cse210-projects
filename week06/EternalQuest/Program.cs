// EXCEEDS REQUIREMENTS:
// 1. Awards bonus points for checklist goals when the user completes the required number of repetitions. 
//    When a checklist goal is completed, the user receives a congratulatory message and the bonus points are added to their score.
// 2. Displays a special message to celebrate the user's achievement when a checklist goal is completed.


using System;
using System.Collections.Generic;
using System.IO;

// Base class for all goals
abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    public string Name { get => _name; protected set => _name = value; }
    public string Description { get => _description; protected set => _description = value; }
    public int Points { get => _points; protected set => _points = value; }
    public abstract bool IsComplete { get; }
    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
    public static Goal Deserialize(string data)
    {
        var parts = data.Split('|');
        switch (parts[0])
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new Exception("Unknown goal type");
        }
    }
}

// Simple goal: complete once
class SimpleGoal : Goal
{
    private bool _isComplete;
    public override bool IsComplete => _isComplete;
    public SimpleGoal(string name, string desc, int points, bool isComplete = false)
    {
        Name = name; Description = desc; Points = points; _isComplete = isComplete;
    }
    public override void RecordEvent() { _isComplete = true; }
    public override string GetStatus() => $"[{"X",1}] {Name} ({Description})";
    public override string Serialize() => $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
}

// Eternal goal: repeatable, never complete
class EternalGoal : Goal
{
    private int _timesCompleted;
    public override bool IsComplete => false;
    public EternalGoal(string name, string desc, int points, int timesCompleted = 0)
    {
        Name = name; Description = desc; Points = points; _timesCompleted = timesCompleted;
    }
    public override void RecordEvent() { _timesCompleted++; }
    public override string GetStatus() => $"[ ] {Name} ({Description}) -- Completed {_timesCompleted} times";
    public override string Serialize() => $"EternalGoal|{Name}|{Description}|{Points}|{_timesCompleted}";
}

// Checklist goal: complete X times for bonus
class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _currentCount;
    public override bool IsComplete => _currentCount >= _targetCount;
    public ChecklistGoal(string name, string desc, int points, int targetCount, int bonus, int currentCount = 0)
    {
        Name = name; Description = desc; Points = points; _targetCount = targetCount; _bonus = bonus; _currentCount = currentCount;
    }
    public override void RecordEvent()
    {
        if (_currentCount < _targetCount) _currentCount++;
    }
    public override string GetStatus()
    {
        string mark = IsComplete ? "X" : " ";
        return $"[{mark}] {Name} ({Description}) -- Completed {_currentCount}/{_targetCount} times";
    }
    public override string Serialize() => $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    public int GetBonus() => IsComplete && _currentCount == _targetCount ? _bonus : 0;
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        LoadGoals();
        while (true)
        {
            Console.WriteLine($"\nYour score: {score}");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": ListGoals(); break;
                case "2": CreateGoal(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": SaveGoals(); return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist");
        string type = Console.ReadLine();
        Console.Write("Goal name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());
        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times to complete? "); int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion: "); int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? (number): ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= goals.Count)
        {
            var goal = goals[idx - 1];
            goal.RecordEvent();
            score += goal.Points;
            if (goal is ChecklistGoal cg && cg.GetBonus() > 0)
            {
                score += cg.GetBonus();
                Console.WriteLine($"Bonus! You earned {cg.GetBonus()} extra points!");
            }
            Console.WriteLine($"You earned {goal.Points} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(score);
            foreach (var goal in goals)
                sw.WriteLine(goal.Serialize());
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;
        goals.Clear();
        var lines = File.ReadAllLines("goals.txt");
        if (lines.Length == 0) return;
        score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
            goals.Add(Goal.Deserialize(lines[i]));
        Console.WriteLine("Goals loaded.");
    }
}
