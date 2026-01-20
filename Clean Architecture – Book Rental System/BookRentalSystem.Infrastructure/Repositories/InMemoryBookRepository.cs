using BookRentalSystem.Application.Interface;
using BookRentalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalSystem.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(b => b.ID == id);
        }

        public List<Book> GetAll()
        {
            return _books;
        }
    }
}
