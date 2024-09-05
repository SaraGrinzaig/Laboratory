using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<OrderDto> CreateOrder([FromBody] OrderDto order)
        {
            if (order == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = addedOrder.Id }, addedOrder);
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }
            return Ok(orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public ActionResult<OrderDto> UpdateOrder(int id, [FromBody] OrderDto order)
        {
            if (order == null || !ModelState.IsValid || order.Id != id)
            {
                return BadRequest(ModelState);
            }
            var existingOrder = _orderService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            _orderService.UpdateOrder(order);
            return Ok(order);
        }

        // DELETE: api/Order/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
