using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Application.Interface;

namespace BookRentalSystem.Application.Services
{
    public class BorrowBook
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public BorrowBook(IUserRepository userRepository,IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public void Execute(int userId, int bookId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new Exception("User not found.");

            var book = _bookRepository.GetById(bookId);
            if (book == null)
                throw new Exception("Book not found.");

            book.Borrow();
        }
    }
}
