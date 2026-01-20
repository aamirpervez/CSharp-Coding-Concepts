using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Domain.Entities
{
    public class CarDetail
    {
        public string CarNumber { get; private set; }
        public string OwnerName { get; private set; }

        public CarDetail(string carNumber, string ownerName)
        {
            CarNumber = carNumber;
            OwnerName = ownerName;
        }
    }
}
