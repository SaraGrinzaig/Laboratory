using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly LaboratoryContext _context;

        public StatisticRepository(LaboratoryContext context)
        {
            _context = context;
        }

        // Method to get the number of devices added each month for the year
        public Dictionary<int, int> GetDevicesPerMonth()
        {
            return _context.Statuses
                .Where(s => s.StatusNavigation.StatusName == "נכנס" && s.StatusChangeDate.HasValue && s.StatusChangeDate.Value.Year == DateTime.Now.Year)
                .GroupBy(s => s.StatusChangeDate.Value.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Month, x => x.Count);
        }

        // Method to get the number of devices in the lab by day
        public Dictionary<DateTime, int> GetDevicesPerDay()
        {
            return _context.Statuses
                .Where(s => s.StatusNavigation.StatusName == "נכנס" && s.StatusChangeDate.HasValue)
                .GroupBy(s => s.StatusChangeDate.Value.Date)
                .Select(g => new { Day = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Day, x => x.Count);
        }

        // Method to get the number of devices by status
        public Dictionary<string, int> GetDevicesByStatus()
        {
            // שליפת כל הסטטוסים כולל הניווט ל-StatusType
            var statuses = _context.Statuses
                .Include(s => s.StatusNavigation)
                .ToList(); // שליפת כל הסטטוסים בזיכרון

            // מציאת הסטטוס האחרון לכל מכשיר
            var latestStatuses = statuses
                .GroupBy(s => s.DeviceId)
                .Select(g => g.OrderByDescending(s => s.StatusChangeDate).FirstOrDefault()) // שליפת הסטטוס העדכני ביותר לכל מכשיר
                .Where(s => s?.StatusNavigation != null) // בדיקה שהסטטוס וניווט הסטטוס אינם null
                .ToList();

            // קיבוץ לפי שם הסטטוס
            return latestStatuses
                .GroupBy(s => s.StatusNavigation.StatusName)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Status, x => x.Count); // החזרת מילון עם שם הסטטוס ומספר המכשירים
        }



        // Additional method idea: Number of devices by device type (e.g., Phone, Computer, Other)
        public Dictionary<string, int> GetDevicesByType()
        {
            return _context.Devices
                .GroupBy(d => d.DeviceType)
                .Select(g => new { DeviceType = g.Key, Count = g.Count() })
                .ToDictionary(x => x.DeviceType, x => x.Count);
        }
    }
}
