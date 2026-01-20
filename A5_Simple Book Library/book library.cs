using System;
using System.Runtime.Intrinsics.X86;
namespace book_library
{
    //Book class
    class Book
    {
        //seting a book properties
        public string Title { get; set; }
        public string Author { get; set; }

        // the book availablility true by default 
        public bool IsAvailable { get;private set; } = true;

        //method for borrowing book
        public void BorrowBook()
        {
            // if book is available this part run
            if (IsAvailable == true)
            {
                IsAvailable = false;
                Console.WriteLine($"You Successfully Borrowed The Book of {Title}");
            }
            // if not this work
            else
            {
                Console.WriteLine("This Book is Not Available");
            }
        }

        // method for returing the book
        public void ReturnBook()
        {
            IsAvailable = true;
            Console.WriteLine($"Book of {Title} returned successfully");
        }

        // displying book info
        public void DisplayStatus()
        {
            Console.WriteLine($"Book Title: {Title}");
            Console.WriteLine($"Book Author: {Author}");
            Console.WriteLine($"Book Availability: {IsAvailable}");
        }
    }

    class Program
    {
        //main entry point method
        static void Main( string[] args)
        {
            //creating 5 books and seting its properties
            Book b1 = new Book();
            b1.Title = "Shadow and Bone";
            b1.Author = "Leigh Bardugo";

            Book b2 = new Book();
            b2.Title = "The Witcher: The Last Wish";
            b2.Author = "Andrzej Sapkowski";

            Book b3 = new Book();
            b3.Title = "3 Body Problem";
            b3.Author = "Cixin Liu";

            Book b4 = new Book();
            b4.Title = "Harry Potter and the Sorcerer’s Stone";
            b4.Author = "J.K. Rowling";

            Book b5 = new Book();
            b5.Title = "The Da Vinci Code";
            b5.Author = "Dan Brown";

            //borrowing the book3 book2 book5 and then return the book3
            b3.BorrowBook();
            b5.BorrowBook();
            b1.BorrowBook();
            b3.ReturnBook();

            //create a list to store all books in collection
            List<Book> list = new List<Book>();
            list.Add(b1);
            list.Add(b2);
            list.Add(b3);
            list.Add(b4);
            list.Add(b5);

            //loop for list collection of books for checking one by one
            for (int i = 0; i < list.Count; i++)
            {
                //only show the available books
                if(list[i].IsAvailable == true)
                {
                    list[i].DisplayStatus();
                }
            }
        }
    }
}