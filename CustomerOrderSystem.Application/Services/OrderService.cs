
using CustomerOrderSystem.Domain.Repositories;
using CustomerOrderSystem.Domain.Entities;
using CustomerOrderSystem.Application.DTOs;
namespace CustomerOrderSystem.Application.Services {
    public class OrderService {
        private readonly IOrderRepository _repository;
        
        public OrderService(IOrderRepository repository) {
            _repository = repository;
        }

        public Guid CreateOrder(Guid customerId, List<OrderItem> items) {
            var order = new Order(customerId, items);
            _repository.Save(order);
            return order.OrderId;
        }

        public Order? FindById(Guid orderId) {
            return _repository.FindById(orderId);
        }

        public void PayOrder(Guid orderId) {
            var order = _repository.FindById(orderId) ?? throw new InvalidOperationException("Order not found.");
            order.Pay();
            _repository.Save(order);
        }

        public void ShipOrder(Guid orderId) {
            var order = _repository.FindById(orderId) ?? throw new InvalidOperationException("Order not found.");
            order.Ship();
            _repository.Save(order);
        }

        internal object CreateOrder(Guid customerId, List<OrderItemDto> items)
        {
            throw new NotImplementedException();
        }
    }
}
