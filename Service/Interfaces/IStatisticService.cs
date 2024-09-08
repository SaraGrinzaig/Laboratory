
namespace Service.Interfaces
{
    public interface IStatisticService
    {
        Dictionary<int, int> GetDevicesPerMonth();
        Dictionary<DateTime, int> GetDevicesPerDay();
        Dictionary<string, int> GetDevicesByStatus();
        Dictionary<string, int> GetDevicesByType();
    }
}

