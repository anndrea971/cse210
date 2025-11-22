using System;
using System.Collections.Generic;

// --- Comment Class ---
public class Comment
{
    // Attributes (Responsibility: tracking name and text)
    public string _commenterName;
    public string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _commenterName = name;
        _text = text;
    }
}

// --- Video Class ---
public class Video
{
    // Attributes (Responsibility: tracking title, author, length)
    public string _title;
    public string _author;
    public int _lengthSeconds; // Length in seconds

    // Responsibility: storing a list of comments
    public List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>(); // Initialize the list
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Helper method to add a comment (optional, but good practice)
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}

// --- Main Program Logic ---
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Console.WriteLine("---------------------------------------------\n");

        // 1. Create 3 Video objects

        // Video 1
        Video video1 = new Video("C# Class Abstraction Demo", "CodeMaster", 780);
        video1.AddComment(new Comment("Alice", "Great explanation of the principle!"));
        video1.AddComment(new Comment("Bob", "This helped me a lot with my assignment."));
        video1.AddComment(new Comment("Charlie", "Could you do a video on inheritance next?"));

        // Video 2
        Video video2 = new Video("Intro to .NET Framework", "Tech Guru", 545);
        video2.AddComment(new Comment("Eve", "Very clear and concise. Thanks!"));
        video2.AddComment(new Comment("Frank", "Where can I find the source code?"));
        video2.AddComment(new Comment("Grace", "Good examples."));
        video2.AddComment(new Comment("Heidi", "The pace was perfect for beginners."));

        // Video 3
        Video video3 = new Video("Top 5 Dev Tools for 2024", "DevDaily", 1200);
        video3.AddComment(new Comment("Ivan", "I agree with VS Code being number one!"));
        video3.AddComment(new Comment("Judy", "Missing Rider, but still a solid list."));
        video3.AddComment(new Comment("Kevin", "Excellent production quality."));


        // 2. Put each of these videos in a list
        List<Video> videoList = new List<Video> { video1, video2, video3 };


        // 3. Iterate through the list of videos and display information
        Console.WriteLine("--- Displaying Video Information and Comments ---\n");
        
        foreach (Video video in videoList)
        {
            // Display video details
            Console.WriteLine("==================================================");
            Console.WriteLine($"🎬 **TITLE**: {video._title}");
            Console.WriteLine($"👤 **AUTHOR**: {video._author}");
            Console.WriteLine($"⏱️ **LENGTH**: {video._lengthSeconds} seconds");
            
            // Call the method to display the number of comments
            int commentCount = video.GetNumberOfComments();
            Console.WriteLine($"💬 **NUMBER OF COMMENTS**: {commentCount}");
            Console.WriteLine("==================================================");

            // List out all of the comments
            Console.WriteLine("\n**COMMENTS:**");
            if (commentCount > 0)
            {
                foreach (Comment comment in video._comments)
                {
                    Console.WriteLine($"  - {comment._commenterName}: \"{comment._text}\"");
                }
            }
            else
            {
                Console.WriteLine("  (No comments yet.)");
            }
            
            Console.WriteLine("\n" + new string('-', 50) + "\n");
        }
    }
}