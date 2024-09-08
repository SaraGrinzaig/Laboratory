using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStatisticRepository
    {
        Dictionary<int, int> GetDevicesPerMonth();
        Dictionary<DateTime, int> GetDevicesPerDay();
        Dictionary<string, int> GetDevicesByStatus();
        Dictionary<string, int> GetDevicesByType();
    }
}
