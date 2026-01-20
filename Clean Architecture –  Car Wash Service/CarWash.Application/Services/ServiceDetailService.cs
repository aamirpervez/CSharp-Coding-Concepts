using CarWash.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Domain.Interfaces;
using CarWash.Domain.Entities;
using CarWash.Application.Interfaces;


namespace CarWash.Application.Services
{
    public class ServiceDetailService : IServiceDetailService
    {
        private readonly IServiceDetailRepository _serviceRepository;

        public ServiceDetailService(IServiceDetailRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }



        public void AddService(ServiceDetailDTO dto)
        {
            if(string.IsNullOrEmpty(dto.Name))
            {
                throw new ArgumentNullException("Service name can not be empty.");
            }
            if(dto.Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Service price must be greater than zero.");
            }
            var service = new ServiceDetail(dto.Name, dto.Price);
            _serviceRepository.AddService(service);
        }



        public void UpdateService(ServiceDetailDTO dto, int id)
        {
            var service = _serviceRepository.GetServiceById(id);
            service.Name = dto.Name;
            service.Price = dto.Price;
            _serviceRepository.UpdateService(service);
        }



        public void DeleteService(int id)
        {
            _serviceRepository.RemoveService(_serviceRepository.GetServiceById(id));
        }



        public string ViewAllServices()
        {
            var service = _serviceRepository.GetAllServices();

            if (!service.Any())
            {
                throw new Exception("Services are not Available");
            }
            StringBuilder result = new StringBuilder();
            foreach (var srv in service)
            {
                result.AppendLine($"Service ID: {srv.Id}, Name: {srv.Name}, Price: {srv.Price:c}");
            }
            return result.ToString();
        }



        public string ServiceExists(int id)
        {
            ServiceDetail service = _serviceRepository.GetServiceById(id);

            return $"Current Service Details\n \nName: {service.Name}\nPrice: {service.Price}\n";
        }
    }
}
