using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Application.DTOs;
using CarWash.Domain.Entities;
using CarWash.Domain.Interfaces;
namespace CarWash.Infrasturcture.Repositories
{
    public class ServiceDetailRepository : IServiceDetailRepository
    {
        private readonly List<ServiceDetail> _services = new List<ServiceDetail>();
        public void AddService(ServiceDetail service)
        {
            _services.Add(service);
        }

        public List<ServiceDetail> GetAllServices()
        {
            return _services;
        }

        public ServiceDetail GetServiceById(int id)
        {
            var service = _services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                throw new ArgumentException($"Service with id {id} not found.");
            }
            return service;
        }

        public void RemoveService(ServiceDetail service)
        {
            _services.Remove(service);
        }

        public void UpdateService(ServiceDetail service)
        {
            _services.RemoveAll(s => s.Id == service.Id);
            _services.Add(service);
        }
    }
}
