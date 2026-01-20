using CarWash.Application.DTOs;
using CarWash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Application.Interfaces
{
    public interface ICarDetailService
    {
        public void RegisterCarWash(CarDetailDTO dto);
        public string ViewAllCarWashRecords();
    }
}
