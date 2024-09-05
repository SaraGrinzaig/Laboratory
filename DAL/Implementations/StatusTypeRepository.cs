using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            _context.Entry(statusType).State = EntityState.Modified;
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
