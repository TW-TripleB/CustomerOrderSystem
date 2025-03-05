using CustomerOrderSystem.Domain.Enums;
namespace CustomerOrderSystem.Domain.Entities {
    public class Order {
        public Guid OrderId { get; }               // 訂單的唯一標識符
        public Guid CustomerId { get; }            // 顧客的唯一標識符
        private List<OrderItem> _items = new();    // 訂單中的商品項目
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly(); // 訂單項目的只讀屬性
        public OrderStatus Status { get; private set; }  // 訂單狀態
        public decimal TotalAmount => _items.Sum(item => item.Price * item.Quantity);  // 計算訂單總金額

        // 建構函式，若訂單項目為空則會拋出異常
        public Order(Guid customerId, List<OrderItem> items) {
            if (!items.Any()) throw new ArgumentException("Order must contain at least one item.");

            OrderId = Guid.NewGuid();  // 自動生成訂單 ID
            CustomerId = customerId;
            _items = items;  // 初始化訂單項目
            Status = OrderStatus.CREATED;  // 預設訂單狀態為 "CREATED"
        }

        // 付款方法，只有未支付的訂單才能進行付款
        public void Pay() {
            if (Status != OrderStatus.CREATED) throw new InvalidOperationException("Only created orders can be paid.");
            Status = OrderStatus.PAID;  // 改變訂單狀態為 "PAID"
        }

        // 發貨方法，只有已付款的訂單才能進行發貨
        public void Ship() {
            if (Status != OrderStatus.PAID) throw new InvalidOperationException("Only paid orders can be shipped.");
            Status = OrderStatus.SHIPPED;  // 改變訂單狀態為 "SHIPPED"
        }
    }
}
