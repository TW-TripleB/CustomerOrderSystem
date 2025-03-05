using CustomerOrderSystem.Domain.Repositories;
using CustomerOrderSystem.Domain.Entities;
namespace CustomerOrderSystem.Infrastructure.Persistence {
    // 訂單存儲庫的內存實現
    public class InMemoryOrderRepository : IOrderRepository {
        private readonly Dictionary<Guid, Order> _orders = new();  // 使用字典來存儲訂單

        // 根據訂單 ID 查找訂單
        public Order? FindById(Guid orderId) => _orders.TryGetValue(orderId, out var order) ? order : null;

        // 儲存訂單，將其加入字典
        public void Save(Order order) => _orders[order.OrderId] = order;

        // 刪除訂單
        public void Delete(Guid orderId) => _orders.Remove(orderId);
    }
}
