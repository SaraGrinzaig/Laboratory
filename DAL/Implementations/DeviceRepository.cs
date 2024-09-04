using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class DeviceRepository : IDeviceRepository
    {
        private LaboratoryContext _context;

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

        public void AddDevice(Device device)
        {
            _context.Devices.Add(device);
        }

        public void DeleteDevice(int id)
        {
            Device device = _context.Devices.Find(id);
            _context.Devices.Remove(device);
        }

        public void UpdateDevice(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
