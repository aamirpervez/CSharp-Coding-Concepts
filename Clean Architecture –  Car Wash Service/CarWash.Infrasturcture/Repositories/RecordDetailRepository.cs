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
    public class RecordDetailRepository : IRecordDetailRepository
    {
        private readonly List<CarWashRecordDetail> _records = new List<CarWashRecordDetail>();
        public void AddRecord(CarWashRecordDetail record)
        {
            _records.Add(record);
        }

        public List<CarWashRecordDetail> GetAllRecords()
        {
            return _records;
        }
    }
}
