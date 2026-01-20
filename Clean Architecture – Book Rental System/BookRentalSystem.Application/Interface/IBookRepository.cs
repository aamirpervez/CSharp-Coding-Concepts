using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Domain.Entities;

namespace BookRentalSystem.Application.Interface
{
    public interface IBookRepository
    {
        Book GetById(int id);
        List<Book> GetAll();
        void Add(Book book);
    }
}
