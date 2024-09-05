using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly LaboratoryContext _context;

        public DeviceRepository(LaboratoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _context.Devices.ToList();
        }

        public Device GetDeviceById(int id)
        {
            return _context.Devices.Find(id);
        }

        public void InsertDevice(Device device)
        {
            _context.Devices.Add(device);
        }

        public void DeleteDevice(int id)
        {
            var device = _context.Devices.Find(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
            }
        }

        public void UpdateDevice(Device device)
        {
            var existingDevice = _context.Devices.Find(device.Id);
            if (existingDevice != null)
            {
                _context.Entry(existingDevice).CurrentValues.SetValues(device);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
