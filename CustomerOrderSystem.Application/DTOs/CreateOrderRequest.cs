using CustomerOrderSystem.Domain.Entities;
namespace CustomerOrderSystem.Application.DTOs {
    public class CreateOrderRequest {
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public OrderItem ToDomain() => new OrderItem(ProductId, Price, Quantity);
    }
}
