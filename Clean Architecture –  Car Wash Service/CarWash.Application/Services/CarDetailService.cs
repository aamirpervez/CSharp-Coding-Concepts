using CarWash.Application.DTOs;
using CarWash.Domain.Entities;
using CarWash.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Application.Interfaces;

namespace CarWash.Application.Services
{
    public class CarDetailService : ICarDetailService
    {
        private readonly IRecordDetailRepository _recordRepository;
        private readonly IServiceDetailRepository _serviceRepository;
        public CarDetailService(IRecordDetailRepository carWashRepository, IServiceDetailRepository serviceRepository)
        {
            _recordRepository = carWashRepository;
            _serviceRepository = serviceRepository;
        }



        public void RegisterCarWash(CarDetailDTO dto)
        {
            if (string.IsNullOrEmpty(dto.CarNumber))
            {
                throw new ArgumentNullException("Car number can not be empty.");
            }
            if (string.IsNullOrEmpty(dto.OwnerName))
            {
                throw new ArgumentNullException("Owner name can not be empty.");
            }
            var car = new CarDetail(dto.CarNumber, dto.OwnerName);

            DateTime current = DateTime.Now;

            var service = _serviceRepository.GetServiceById(dto.ServiceId);

            var record = new CarWashRecordDetail(car, service, current);

            _recordRepository.AddRecord(record);
        }



        public string ViewAllCarWashRecords()
        {
            var records = _recordRepository.GetAllRecords();

            if (!records.Any())
            {
                throw new InvalidOperationException("No car wash records found.");
            }
            StringBuilder result = new StringBuilder();
            foreach (var record in records)
            {
                result.AppendLine($"Car Number: {record.CarDetail.CarNumber}, Owner: {record.CarDetail.OwnerName}, Service: {record.ServiceDetail.Name}, Price: {record.ServiceDetail.Price:c}, Date: {record.WashDate:g}");
            }
            return result.ToString();
        }
    }
}
