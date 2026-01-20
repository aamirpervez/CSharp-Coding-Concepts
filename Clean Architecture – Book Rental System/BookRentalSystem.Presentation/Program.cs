using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Application.Services;
using BookRentalSystem.Domain.Entities;
using BookRentalSystem.Infrastructure.Repositories;

namespace BookRentalSystem.Presentation
{
    static class Program
    {
         static void Main(string[] args)
        {
            // Infrastructure
            var userRepository = new InMemoryUserRepository();
            var bookRepository = new InMemoryBookRepository();

            var borrowBookUseCase = new BorrowBook(userRepository, bookRepository);

            userRepository.Add(new User(1, "Ali"));
            userRepository.Add(new User(2, "Sara"));

            bookRepository.Add(new Book(1, "Clean Architecture"));
            bookRepository.Add(new Book(2, "C# Fundamentals"));

            while (true)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. View Available Books");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                var choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        Console.Write("Enter User Id: ");
                        int userId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Book Id: ");
                        int bookId = int.Parse(Console.ReadLine());

                        borrowBookUseCase.Execute(userId, bookId);
                        Console.WriteLine("Book borrowed successfully!");
                    }
                    else if (choice == "2")
                    {
                        foreach (var book in bookRepository.GetAll())
                        {
                            if (!book.IsBorrowed)
                                Console.WriteLine($"{book.ID} - {book.Title}");
                        }
                    }
                    else if (choice == "3")
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
