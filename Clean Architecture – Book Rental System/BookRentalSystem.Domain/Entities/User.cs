using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalSystem.Domain.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public String Name { get; private set; }

        public User(int id, String name)
        {
            ID = id;
            Name = name;
        }
    }
}
