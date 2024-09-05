using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
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
        }

        public void DeleteStatus(int statusId)
        {
            var status = _context.Statuses.Find(statusId);
            if (status != null)
            {
                _context.Statuses.Remove(status);
            }
        }

        public void UpdateStatus(Status status)
        {
            var existingStatus = _context.Statuses.Find(status.Id);
            if (existingStatus != null)
            {
                _context.Entry(existingStatus).CurrentValues.SetValues(status);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
