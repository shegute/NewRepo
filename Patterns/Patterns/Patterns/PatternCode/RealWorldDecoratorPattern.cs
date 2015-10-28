using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Decorator.RealWorld
{
    /// <summary>MainApp startup class for Real-World. Decorator Design Pattern.</summary>
    class RealWorldDecoratorMainApp
    {
        /// <summary>Entry point into console application.</summary>
        public static void Run()
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");
            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");
            borrowvideo.Display();

            borrowvideo.ReturnItem("Customer #13");
            borrowvideo.Display();

            Console.WriteLine("\nShow story line: for borrowable video");
            StoryLine storyLine = new StoryLine(borrowvideo);
            storyLine.AddCharacter("Lex Luther");
            storyLine.AddCharacter("Clark");
            storyLine.AddCharacter("Wendy");
            storyLine.Display();

            Console.WriteLine("\nShow story line: for video");
            storyLine = new StoryLine(video);
            storyLine.AddCharacter("Dr. Jekyll");
            storyLine.AddCharacter("Sylia");
            storyLine.AddCharacter("Hyde");
            storyLine.Display();


            Console.WriteLine("\nShow story line: for book");
            storyLine = new StoryLine(book);
            storyLine.AddCharacter("Winston");
            storyLine.AddCharacter("Obrien");
            storyLine.AddCharacter("Julia");
            storyLine.Display();
            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>The 'Component' abstract class</summary>
    abstract class LibraryItem
    {
        private int _numCopies;

        // Property
        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }

    /// <summary>The 'ConcreteComponent' class</summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>The 'ConcreteComponent' class </summary>
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor
        public Video(string director, string title, int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    /// <summary>The 'Decorator' abstract class</summary>
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        // Constructor
        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }

    /// <summary> The 'ConcreteDecorator' class </summary>
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        // Constructor
        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }


    /// <summary> The 'ConcreteDecorator' class </summary>
    class StoryLine : Decorator
    {
        protected List<string> mainCharacters = new List<string>();

        // Constructor
        public StoryLine(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void AddCharacter(string name)
        {
            mainCharacters.Add(name);
        }

        public override void Display()
        {
            base.Display();

            foreach (string character in mainCharacters)
            {
                Console.WriteLine(" character: " + character);
            }
        }
    }
}

