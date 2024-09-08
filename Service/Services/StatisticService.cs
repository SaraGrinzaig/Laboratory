using DAL.Interfaces;
using DAL.Repositories;
using Service.Interfaces;

namespace Service.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticsRepository;

        public StatisticService(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        // Method to get devices per month for the graph
        public Dictionary<int, int> GetDevicesPerMonth()
        {
            return _statisticsRepository.GetDevicesPerMonth();
        }

        // Method to get devices per day for daily statistics
        public Dictionary<DateTime, int> GetDevicesPerDay()
        {
            return _statisticsRepository.GetDevicesPerDay();
        }

        // Method to get devices by status for the dashboard
        public Dictionary<string, int> GetDevicesByStatus()
        {
            return _statisticsRepository.GetDevicesByStatus();
        }

        // Method to get devices by type (e.g., Phone, Computer) for additional statistics

        public Dictionary<string, int> GetDevicesByType()
        {
            return _statisticsRepository.GetDevicesByType();
        }
    }
}
