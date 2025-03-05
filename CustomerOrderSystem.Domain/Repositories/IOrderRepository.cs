
using CustomerOrderSystem.Domain.Entities;
namespace CustomerOrderSystem.Domain.Repositories {
    // 定義訂單存取接口
    public interface IOrderRepository {
        Order? FindById(Guid orderId);  // 根據訂單 ID 查找訂單
        void Save(Order order);         // 儲存訂單
        void Delete(Guid orderId);     // 刪除訂單
    }
}