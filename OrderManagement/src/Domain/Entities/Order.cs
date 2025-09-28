using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public sealed class Order
    {
        private readonly List<OrderItem> _items = [];
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public OrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal Total => _items.Aggregate(0M, (acc, it) => acc + it.LineTotal);

        internal Order() { }

        public static Order Create(long customerId)
        {
            var order = new Order()
            {
                CustomerId = customerId,
                Status = OrderStatus.Draft,
                CreatedAtUtc = DateTime.UtcNow,
            };
            return order;
        }
        public void AddItem(long productId, int quantity, decimal unitPrice)
        {
            EnsureDraft();
            var existing = _items.FirstOrDefault(x => x.ProductId == productId);
            if (existing is null)
            {
                _items.Add(new OrderItem(productId, quantity, unitPrice));
            }
            else
            {
                existing.IncreaseQuantity(quantity);
            }
        }

        public void RemoveItem(long productId, int quantity)
        {
            EnsureDraft();
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

            var existing = _items.FirstOrDefault(x => x.ProductId == productId) ?? throw new InvalidOperationException("Item not found.");
            existing.DecreaseQuantity(quantity);
            if (existing.Quantity == 0)
            {
                _items.Remove(existing);
            }
        }

        public void Checkout()
        {
            EnsureDraft();
            if (_items.Count == 0) throw new InvalidOperationException("Cannot checkout an empty order.");
            Status = OrderStatus.Placed;
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Canceled) return;
            EnsureDraft();
            Status = OrderStatus.Canceled;
        }

        private void EnsureDraft()
        {
            if (Status != OrderStatus.Draft)
            {
                throw new InvalidOperationException("Only draft orders can be modified.");
            }
        }
    }
}


