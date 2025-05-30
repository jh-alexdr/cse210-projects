using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display.\n");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _prompt = parts[1],
                    _response = parts[2]
                };
                _entries.Add(entry);
            }
        }
    }
}