using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDeviceById(int id);
        void InsertDevice(Device device);
        void DeleteDevice(int id);
        void UpdateDevice(Device device);
        void Save();
    }
}
