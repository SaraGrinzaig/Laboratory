using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StatusTypeRepository : IStatusTypeRepository
    {
        private readonly LaboratoryContext _context;

        public StatusTypeRepository(LaboratoryContext context)
        {
            _context = context;
        }

        public StatusType GetById(int id)
        {
            return _context.StatusTypes.Find(id);
        }

        public StatusType GetByName(string statusName)
        {
            return _context.StatusTypes.FirstOrDefault(st => st.StatusName == statusName);
        }

        public IEnumerable<StatusType> GetAllStatusTypes()
        {
            return _context.StatusTypes.ToList();
        }

        public void InsertStatusType(StatusType statusType)
        {
            _context.StatusTypes.Add(statusType);
        }

        public void UpdateStatusType(StatusType statusType)
        {
            var existingStatusType = _context.StatusTypes.Find(statusType.Id);
            if (existingStatusType != null)
            {
                _context.Entry(existingStatusType).CurrentValues.SetValues(statusType);
            }
        }

        public void DeleteStatusType(int id)
        {
            var statusType = _context.StatusTypes.Find(id);
            if (statusType != null)
            {
                _context.StatusTypes.Remove(statusType);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
