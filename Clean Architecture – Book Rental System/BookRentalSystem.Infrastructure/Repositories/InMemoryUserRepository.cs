using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRentalSystem.Application.Interface;
using BookRentalSystem.Domain.Entities;

namespace BookRentalSystem.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.ID == id);
        }
    }
}
