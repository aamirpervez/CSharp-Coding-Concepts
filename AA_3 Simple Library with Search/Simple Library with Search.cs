using System;
using System.ComponentModel;
using System.Threading.Channels;

namespace Simple_Library_with_Search
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public bool IsAvailable { get; set; }
    }

    class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public static int TotalBooks = 0;

        public void AddBook(Book book)
        {
            Books.Add(book);
            TotalBooks++;
        }

        public void FindBooksByAuthor(string author)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if(Books[i].Author == author && Books[i].IsAvailable == true)
                {
                    Console.WriteLine($"Found: {Books[i].Title}. Author: {Books[i].Author}.");
                }
            }
        }

        public void FindAvailableBooks()
        {
            Console.WriteLine("Available Books");
            for(int i = 0;i < Books.Count; i++)
            {
                if(Books[i].IsAvailable == true)
                {
                    Console.WriteLine($"Title: {Books[i].Title}");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book();
            book1.Title = "The Great Gatsby";
            book1.Author = "F. Scott Fitzgerald";
            book1.ISBN = 978 - 0743273565;
            book1.IsAvailable = true;

            Book book2 = new Book();
            book2.Title = "To Kill a Mockingbird";
            book2.Author = "Harper Lee";
            book2.ISBN = 978 - 0061120084;
            book2.IsAvailable = false;

            Book book3 = new Book();
            book3.Title = "1984";
            book3.Author = "George Orwell";
            book3.ISBN = 978 - 0451524935;
            book3.IsAvailable = true;

            Book book4 = new Book();
            book4.Title = "The Catcher in the Rye";
            book4.Author = "J.D. Salinger";
            book4.ISBN = 978 - 0316769488;
            book4.IsAvailable = false;

            Book book5 = new Book();
            book5.Title = "The Alchemist";
            book5.Author = "Paulo Coelho";
            book5.ISBN = 978 - 0061122415;
            book5.IsAvailable = true;

            Book book6 = new Book();
            book6.Title = "The Pilgrimage";
            book6.Author = "Paulo Coelho";
            book6.ISBN = 978 - 0061687457;
            book6.IsAvailable = true;


            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);
            library.AddBook(book6);

            library.FindBooksByAuthor("Paulo Coelho");
            Console.WriteLine();
            library.FindAvailableBooks();
            Console.WriteLine();
            Console.WriteLine($"Total Number of Books. {Library.TotalBooks}");
        }
    }
}