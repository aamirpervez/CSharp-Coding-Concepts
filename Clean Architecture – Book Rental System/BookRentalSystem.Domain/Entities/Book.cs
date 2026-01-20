using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalSystem.Domain.Entities
{
    public class Book
    {
        public int ID { get; private set; }
        public string Title { get; private set; }
        public bool IsBorrowed { get; private set; }

        public Book(int id,string title)
        {
            ID = id;
            Title = title;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (IsBorrowed)
            {
                throw new InvalidOperationException("Book is already borrowed");
            }
            IsBorrowed=true;
        }
    }
}
