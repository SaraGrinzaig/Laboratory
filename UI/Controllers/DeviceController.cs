using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        // POST: api/Device
        [HttpPost]
        public ActionResult<DeviceDto> CreateDevice([FromBody] DeviceDto device)
        {
            if (device == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedDevice = _deviceService.CreateDevice(device);
            return CreatedAtAction(nameof(GetDeviceById), new { id = addedDevice.Id }, addedDevice);
        }

        // GET: api/Device
        [HttpGet]
        public ActionResult<IEnumerable<DeviceDto>> GetAllDevices()
        {
            var devices = _deviceService.GetAllDevices();
            if (devices == null || !devices.Any())
            {
                return NotFound("No devices found.");
            }
            return Ok(devices);
        }

        // GET: api/Device/{id}
        [HttpGet("{id}")]
        public ActionResult<DeviceDto> GetDeviceById(int id)
        {
            var device = _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound($"Device with ID {id} not found.");
            }
            return Ok(device);
        }

        // PUT: api/Device/{id}
        [HttpPut("{id}")]
        public ActionResult<DeviceDto> UpdateDevice(int id, [FromBody] DeviceDto device)
        {
            if (device == null || !ModelState.IsValid || device.Id != id)
            {
                return BadRequest(ModelState);
            }
            var existingDevice = _deviceService.GetDeviceById(id);
            if (existingDevice == null)
            {
                return NotFound($"Device with ID {id} not found.");
            }
            _deviceService.UpdateDevice(device);
            return Ok(device);
        }

        // DELETE: api/Device/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            var device = _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound($"Device with ID {id} not found.");
            }
            _deviceService.DeleteDevice(id);
            return NoContent();
        }
    }
}
