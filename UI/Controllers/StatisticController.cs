using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticsService;

        public StatisticController(IStatisticService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        // GET: api/statistic/devices-per-month
        [HttpGet("devices-per-month")]
        public IActionResult GetDevicesPerMonth()
        {
            var data = _statisticsService.GetDevicesPerMonth();
            return Ok(data);
        }

        // GET: api/statistic/devices-per-day
        [HttpGet("devices-per-day")]
        public IActionResult GetDevicesPerDay()
        {
            var data = _statisticsService.GetDevicesPerDay();
            return Ok(data);
        }

        // GET: api/statistic/devices-by-status
        [HttpGet("devices-by-status")]
        public IActionResult GetDevicesByStatus()
        {
            var data = _statisticsService.GetDevicesByStatus();
            return Ok(data);
        }

        // GET: api/statistic/devices-by-type
        [HttpGet("devices-by-type")]
        public IActionResult GetDevicesByType()
        {
            var data = _statisticsService.GetDevicesByType();
            return Ok(data);
        }
    }
}
