using System;
using System.Collections.Generic;

// Exceeding requirements: 
// - This program supports both single and multiple verse references.
// - The code is structured for easy extension to load scriptures from a file or library.
// - Now supports a library of scriptures and randomly selects one for the user.

class Program
{
    static void Main(string[] args)
    {
        // Scripture library
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(
                new Reference("2 Corinthians", 4, 8, 9),
                "We are troubled on every side, yet not distressed; we are perplexed, but not in despair; persecuted, but not forsaken; cast down, but not destroyed."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Ether", 12, 27),
                "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            )
        };

        // Display scripture options
        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < scriptureLibrary.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptureLibrary[i].GetReference()}");
        }

        int selection = 0;
        while (selection < 1 || selection > scriptureLibrary.Count)
        {
            Console.Write("Enter the number of your choice: ");
            string input = Console.ReadLine();
            int.TryParse(input, out selection);
        }

        Scripture scripture = scriptureLibrary[selection - 1];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
                break;

            scripture.HideRandomWords(3); // Hide 3 random words per round
        }

        // Final display
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Press Enter to exit.");
        Console.ReadLine();
    }
}

// Represents a scripture reference (e.g., "2 Corinthians 4:8-9")
class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (_verseEnd.HasValue)
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{_book} {_chapter}:{_verseStart}";
    }
}

// Represents a single word in the scripture
class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public bool IsHidden() => _hidden;

    public void Hide() => _hidden = true;

    public string GetDisplayText()
    {
        if (_hidden)
            return new string('_', _text.Length);
        else
            return _text;
    }
}

// Represents the scripture (reference + words)
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' '))
            _words.Add(new Word(word));
    }

    public string GetDisplayText()
    {
        string words = string.Join(" ", _words.ConvertAll(w => w.GetDisplayText()));
        return $"{_reference}\n{words}";
    }

    public void HideRandomWords(int count)
    {
        var notHidden = new List<int>();
        for (int i = 0; i < _words.Count; i++)
            if (!_words[i].IsHidden())
                notHidden.Add(i);

        if (notHidden.Count == 0)
            return;

        for (int i = 0; i < count && notHidden.Count > 0; i++)
        {
            int idx = _random.Next(notHidden.Count);
            _words[notHidden[idx]].Hide();
            notHidden.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
            if (!word.IsHidden())
                return false;
        return true;
    }

    public string GetReference()
    {
        return _reference.ToString();
    }
}