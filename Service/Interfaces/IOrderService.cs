using Service.DTOs;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int orderId);
        void CreateOrder(OrderDto order);
        void UpdateOrder(OrderDto order);
        void DeleteOrder(int orderId);
    }
}

