using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Application.DTOs
{
    public class CarDetailDTO
    {
        public string CarNumber { get; private set; }
        public string OwnerName { get; private set; }
        public int ServiceId { get; private set; }

        public CarDetailDTO(string carNumber, string ownerName, int serviceId)
        {
            CarNumber = carNumber;
            OwnerName = ownerName;
            ServiceId = serviceId;
        }
    }
}
