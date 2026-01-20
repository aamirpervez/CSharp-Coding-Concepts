using BookRentalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalSystem.Application.Interface
{
    public interface IUserRepository
    {
        User GetById(int id);
        void Add(User user);
    }
}
