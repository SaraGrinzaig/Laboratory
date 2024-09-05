using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // POST: api/Status
        [HttpPost]
        public ActionResult<StatusDto> CreateStatus([FromBody] StatusDto status)
        {
            if (status == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedStatus = _statusService.CreateStatus(status);
            return CreatedAtAction(nameof(GetStatusById), new { id = addedStatus.Id }, addedStatus);
        }

        // GET: api/Status
        [HttpGet]
        public ActionResult<IEnumerable<StatusDto>> GetAllStatuses()
        {
            var statuses = _statusService.GetAllStatuses();
            if (statuses == null || !statuses.Any())
            {
                return NotFound("No statuses found.");
            }
            return Ok(statuses);
        }

        // GET: api/Status/{id}
        [HttpGet("{id}")]
        public ActionResult<StatusDto> GetStatusById(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }
            return Ok(status);
        }

        // PUT: api/Status/{id}
        [HttpPut("{id}")]
        public ActionResult<StatusDto> UpdateStatus(int id, [FromBody] StatusDto status)
        {
            if (status == null || !ModelState.IsValid || status.Id != id)
            {
                return BadRequest(ModelState);
            }
            var existingStatus = _statusService.GetStatusById(id);
            if (existingStatus == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }
            _statusService.UpdateStatus(status);
            return Ok(status);
        }

        // DELETE: api/Status/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStatus(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null)
            {
                return NotFound($"Status with ID {id} not found.");
            }
            _statusService.DeleteStatus(id);
            return NoContent();
        }
    }
}
