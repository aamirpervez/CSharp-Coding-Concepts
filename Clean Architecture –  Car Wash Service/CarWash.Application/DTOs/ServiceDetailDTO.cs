using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Application.DTOs
{
    public class ServiceDetailDTO
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public ServiceDetailDTO(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
