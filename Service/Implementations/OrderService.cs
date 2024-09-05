using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Service.DTOs;
using Service.Interfaces;

namespace Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public OrderDto GetOrderById(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public OrderDto CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.InsertOrder(order);
            _orderRepository.Save();
            return _mapper.Map<OrderDto>(order);
        }

        public void UpdateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _orderRepository.UpdateOrder(order);
            _orderRepository.Save();
        }

        public void DeleteOrder(int orderId)
        {
            _orderRepository.DeleteOrder(orderId);
            _orderRepository.Save();
        }
    }
}

