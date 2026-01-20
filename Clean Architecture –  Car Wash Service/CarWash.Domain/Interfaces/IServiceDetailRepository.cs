using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Domain.Entities;

namespace CarWash.Domain.Interfaces
{
    public interface IServiceDetailRepository
    {
        void AddService(ServiceDetail service);
        void RemoveService(ServiceDetail service);
        void UpdateService(ServiceDetail service);
        ServiceDetail GetServiceById(int id);
        List<ServiceDetail> GetAllServices();
    }
}
