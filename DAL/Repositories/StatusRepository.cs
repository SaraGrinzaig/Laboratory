using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly LaboratoryContext _context;

        public StatusRepository(LaboratoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            return _context.Statuses.ToList();
        }

        public Status GetStatusById(int statusId)
        {
            return _context.Statuses.Find(statusId);
        }

        public void InsertStatus(Status status)
        {
            _context.Statuses.Add(status);
            _context.SaveChanges();
        }

        public void DeleteStatus(int statusId)
        {
            var status = _context.Statuses.Find(statusId);
            if (status != null)
            {
                _context.Statuses.Remove(status);
            }
            _context.SaveChanges();
        }

        public void UpdateStatus(Status status)
        {
            var existingStatus = _context.Statuses.Find(status.Id);
            if (existingStatus != null)
            {
                _context.Entry(existingStatus).CurrentValues.SetValues(status);
            }
            _context.SaveChanges();
        }

        public Status GetCurrentStatusForDevice(int deviceId)
        {
            return _context.Statuses
                .Where(s => s.DeviceId == deviceId)
                .OrderByDescending(s => s.Id) 
                .FirstOrDefault();
        }

    }
}
