using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerDto customer)
        {
            if (customer == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedCustomer = _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = addedCustomer.Id }, addedCustomer);
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            if (customers == null || !customers.Any())
            {
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }


        // GET: api/Customer/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            if (customer == null || !ModelState.IsValid || customer.Id != id)
            {
                return BadRequest(ModelState);
            }
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _customerService.UpdateCustomer(customer);
            return Ok(customer);
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
