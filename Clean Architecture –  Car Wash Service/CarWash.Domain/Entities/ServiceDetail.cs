using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Domain.Entities
{
    public class ServiceDetail
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Id { get; private set; }

        private static int IdCounter = 0;
        public ServiceDetail( string name, double price)
        {
            IdCounter++;
            Id = IdCounter;
            Name = name;
            Price = price;
        }
    }
}
