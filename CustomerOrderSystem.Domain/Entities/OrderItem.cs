namespace CustomerOrderSystem.Domain.Entities {
    public class OrderItem {
        public Guid ProductId { get; }  // 產品的唯一標識符
        public decimal Price { get; }   // 單價
        public int Quantity { get; }    // 數量

        // 建構函式，若數量或價格為零或負數則會拋出異常
        public OrderItem(Guid productId, decimal price, int quantity) {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.");
            if (price <= 0) throw new ArgumentException("Price must be greater than zero.");

            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
