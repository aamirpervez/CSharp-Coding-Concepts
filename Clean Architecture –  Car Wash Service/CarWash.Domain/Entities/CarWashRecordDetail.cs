using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Domain.Entities
{
    public class CarWashRecordDetail
    {
        public CarDetail CarDetail { get; private set; }
        public ServiceDetail ServiceDetail { get; private set; }
        public DateTime WashDate { get; private set; }

        public CarWashRecordDetail(CarDetail car, ServiceDetail service, DateTime washDate)
        {
            CarDetail = car;
            ServiceDetail = service;
            WashDate = washDate;
        }
    }
}
