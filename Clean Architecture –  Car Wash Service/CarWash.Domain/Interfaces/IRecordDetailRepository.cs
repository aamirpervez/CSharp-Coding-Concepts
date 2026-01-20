using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Domain.Entities;

namespace CarWash.Domain.Interfaces
{
    public interface IRecordDetailRepository
    {
        void AddRecord(CarWashRecordDetail record);
        List<CarWashRecordDetail> GetAllRecords();
    }
}
