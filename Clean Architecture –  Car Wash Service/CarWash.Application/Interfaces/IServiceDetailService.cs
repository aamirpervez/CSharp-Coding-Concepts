using CarWash.Application.DTOs;
using CarWash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Application.Interfaces
{
    public interface IServiceDetailService
    {
        public void AddService(ServiceDetailDTO dto);
        public void UpdateService(ServiceDetailDTO dto, int id);
        public void DeleteService(int id);
        public string ViewAllServices();
        public string ServiceExists(int id);
    }
}
