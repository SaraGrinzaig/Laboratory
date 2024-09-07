using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatuses();
        Status GetStatusById(int statusId);
        void InsertStatus(Status status);
        void DeleteStatus(int statusId);
        void UpdateStatus(Status status);
        Status GetCurrentStatusForDevice(int deviceId);
    }

}
