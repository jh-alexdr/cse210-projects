using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var videos = new List<Video>();

        var video1 = new Video("How to Cook Pasta", "Chef Mario", 420);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it."));
        video1.AddComment(new Comment("Charlie", "Can you do a gluten-free version?"));
        videos.Add(video1);

        var video2 = new Video("Guitar Tutorial for Beginners", "MusicMan", 900);
        video2.AddComment(new Comment("Dave", "Very helpful, thanks!"));
        video2.AddComment(new Comment("Eve", "What guitar are you using?"));
        video2.AddComment(new Comment("Frank", "Loved the tips on finger placement."));
        videos.Add(video2);

        var video3 = new Video("Top 10 Travel Destinations", "Wanderlust", 600);
        video3.AddComment(new Comment("Grace", "Adding these to my bucket list!"));
        video3.AddComment(new Comment("Heidi", "Beautiful places."));
        video3.AddComment(new Comment("Ivan", "Can you do a video on budget travel?"));
        videos.Add(video3);

        var video4 = new Video("Learn C# in 10 Minutes", "CodeMaster", 650);
        video4.AddComment(new Comment("Judy", "Super concise and clear."));
        video4.AddComment(new Comment("Ken", "Helped me with my homework."));
        video4.AddComment(new Comment("Leo", "Can you make one for Python?"));
        videos.Add(video4);

        // Display videos and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}