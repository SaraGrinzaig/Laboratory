using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class StatusRepository : IStatusRepository
    {
        private LaboratoryContext _context;

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
            Status status = _context.Statuses.Find(statusId);
            if (status != null)
            {
                _context.Statuses.Remove(status);
            }
        }

        public void UpdateStatus(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
