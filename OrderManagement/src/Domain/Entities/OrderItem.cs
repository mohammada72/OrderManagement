namespace OrderManagement.Domain.Entities
{
    public sealed class OrderItem
    {
        public long Id { get; set; }
        public long ProductId { get; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; }
        public decimal LineTotal => UnitPrice * Quantity;

        internal OrderItem(long productId,int quantity, decimal unitPrice)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void IncreaseQuantity(int addedQuantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(addedQuantity);
            Quantity += addedQuantity;
        }

        public void DecreaseQuantity(int addedQuantity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(addedQuantity);
            Quantity = Math.Max(0, Quantity - addedQuantity);
        }
    }
}


