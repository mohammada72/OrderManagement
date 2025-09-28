using System;
using NUnit.Framework;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.UnitTests
{
    public class OrderTests
    {
        [Test]
        public void Create_WithValidCustomerId_ReturnsDraftOrder()
        {
            var customerId = 123L;

            var order = Order.Create(customerId);

            Assert.Multiple(() =>
            {
                Assert.That(order.CustomerId, Is.EqualTo(customerId));
                Assert.That(order.Status, Is.EqualTo(OrderStatus.Draft));
                Assert.That(order.Items, Is.Empty);
                Assert.That(order.Total, Is.EqualTo(0M));
                Assert.That(order.CreatedAtUtc, Is.Not.EqualTo(DateTime.MinValue));
            });
        }

        [Test]
        public void AddItem_WithNewProduct_AddsItemToOrder()
        {
            var order = Order.Create(123L);
            var productId = 456L;
            var quantity = 2;
            var unitPrice = 10.50M;

            order.AddItem(productId, quantity, unitPrice);

            Assert.That(order.Items.Count, Is.EqualTo(1));
            var item = order.Items.First();
            Assert.Multiple(() =>
            {
                Assert.That(item.ProductId, Is.EqualTo(productId));
                Assert.That(item.Quantity, Is.EqualTo(quantity));
                Assert.That(item.UnitPrice, Is.EqualTo(unitPrice));
                Assert.That(order.Total, Is.EqualTo(21.00M));
            });
        }

        [Test]
        public void AddItem_WithExistingProduct_IncreasesQuantity()
        {
            var order = Order.Create(123L);
            var productId = 456L;
            order.AddItem(productId, 2, 10.00M);

            order.AddItem(productId, 3, 10.00M);

            var item = order.Items.First();

            Assert.Multiple(() =>
            {
                Assert.That(order.Items.Count, Is.EqualTo(1));
                Assert.That(item.Quantity, Is.EqualTo(5));
                Assert.That(order.Total, Is.EqualTo(50.00M));
            });
        }

        [Test]
        public void RemoveItem_WithValidProduct_DecreasesQuantity()
        {
            var order = Order.Create(123L);
            var productId = 456L;
            order.AddItem(productId, 5, 10.00M);

            order.RemoveItem(productId, 2);

            var item = order.Items.First();
            Assert.Multiple(() =>
            {
                Assert.That(order.Items.Count, Is.EqualTo(1));
                Assert.That(item.Quantity, Is.EqualTo(3));
                Assert.That(order.Total, Is.EqualTo(30.00M));
            });
        }

        [Test]
        public void RemoveItem_WithZeroQuantity_RemovesItemFromOrder()
        {
            var order = Order.Create(123L);
            var productId = 456L;
            order.AddItem(productId, 2, 10.00M);

            order.RemoveItem(productId, 2);

            Assert.Multiple(() =>
            {
                Assert.That(order.Items, Is.Empty);
                Assert.That(order.Total, Is.EqualTo(0M));
            });
        }

        [Test]
        public void RemoveItem_WithNonExistentProduct_ThrowsException()
        {
            var order = Order.Create(123L);

            Assert.Throws<InvalidOperationException>(() => order.RemoveItem(999L, 1));
        }


        [Test]
        public void Checkout_WithItems_ChangesStatusToPlaced()
        {
            var order = Order.Create(123L);
            order.AddItem(456L, 2, 10.00M);

            order.Checkout();

            Assert.That(order.Status, Is.EqualTo(OrderStatus.Placed));
        }

        [Test]
        public void Checkout_WithEmptyOrder_ThrowsException()
        {
            var order = Order.Create(123L);

            Assert.Throws<InvalidOperationException>(() => order.Checkout());
        }

        [Test]
        public void Cancel_WithDraftOrder_ChangesStatusToCanceled()
        {
            var order = Order.Create(123L);

            order.Cancel();

            Assert.That(order.Status, Is.EqualTo(OrderStatus.Canceled));
        }


        [Test]
        public void AddItem_WithPlacedOrder_ThrowsException()
        {
            var order = Order.Create(123L);
            order.AddItem(456L, 1, 10.00M);
            order.Checkout();

            Assert.Throws<InvalidOperationException>(() => order.AddItem(789L, 1, 5.00M));
        }

        [Test]
        public void RemoveItem_WithPlacedOrder_ThrowsException()
        {
            var order = Order.Create(123L);
            order.AddItem(456L, 2, 10.00M);
            order.Checkout();

            Assert.Throws<InvalidOperationException>(() => order.RemoveItem(456L, 1));
        }

        [Test]
        public void Checkout_WithPlacedOrder_ThrowsException()
        {
            var order = Order.Create(123L);
            order.AddItem(456L, 1, 10.00M);
            order.Checkout();

            Assert.Throws<InvalidOperationException>(() => order.Checkout());
        }
    }
}
