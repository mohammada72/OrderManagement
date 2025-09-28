using System;
using NUnit.Framework;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.UnitTests
{
    public class OrderItemTests
    {
        [Test]
        public void Constructor_WithValidParameters_CreatesOrderItem()
        {
            var productId = 123L;
            var quantity = 5;
            var unitPrice = 15.50M;

            var order = Order.Create(1);
            order.AddItem(productId, quantity, unitPrice);
            var orderItem = order.Items.Last();

            Assert.Multiple(() =>
            {
                Assert.That(orderItem.ProductId, Is.EqualTo(productId));
                Assert.That(orderItem.Quantity, Is.EqualTo(quantity));
                Assert.That(orderItem.UnitPrice, Is.EqualTo(unitPrice));
                Assert.That(orderItem.LineTotal, Is.EqualTo(77.50M));
            });
        }

        [Test]
        public void Constructor_WithZeroQuantity_ThrowsException()
        {
            var productId = 123L;
            var quantity = 0;
            var unitPrice = 15.50M;

            var order = Order.Create(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => order.AddItem(productId, quantity, unitPrice));
        }

        [Test]
        public void Constructor_WithNegativeQuantity_ThrowsException()
        {
            var productId = 123L;
            var quantity = -1;
            var unitPrice = 15.50M;

            var order = Order.Create(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => order.AddItem(productId, quantity, unitPrice));
        }

        [Test]
        public void IncreaseQuantity_WithValidAmount_IncreasesQuantity()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 5, 10.00M);
            var orderItem = order.Items.Last();

            orderItem.IncreaseQuantity(3);

            Assert.Multiple(() =>
            {
                Assert.That(orderItem.Quantity, Is.EqualTo(8));
                Assert.That(orderItem.LineTotal, Is.EqualTo(80.00M));
            });
        }

        [Test]
        public void IncreaseQuantity_WithZeroAmount_ThrowsException()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 5, 10.00M);
            var orderItem = order.Items.Last();

            Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.IncreaseQuantity(0));
        }

        [Test]
        public void IncreaseQuantity_WithNegativeAmount_ThrowsException()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 5, 10.00M);
            var orderItem = order.Items.Last();

            Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.IncreaseQuantity(-1));
        }

        [Test]
        public void DecreaseQuantity_WithValidAmount_DecreasesQuantity()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 10, 5.00M);
            var orderItem = order.Items.Last();

            orderItem.DecreaseQuantity(3);

            Assert.Multiple(() =>
            {
                Assert.That(orderItem.Quantity, Is.EqualTo(7));
                Assert.That(orderItem.LineTotal, Is.EqualTo(35.00M));
            });
        }

        [Test]
        public void DecreaseQuantity_WithAmountGreaterThanQuantity_SetsQuantityToZero()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 3, 10.00M);
            var orderItem = order.Items.Last();

            orderItem.DecreaseQuantity(5);

            Assert.Multiple(() =>
            {
                Assert.That(orderItem.Quantity, Is.EqualTo(0));
                Assert.That(orderItem.LineTotal, Is.EqualTo(0.00M));
            });
        }

        [Test]
        public void DecreaseQuantity_WithZeroAmount_ThrowsException()
        {
            var order = Order.Create(1);
            order.AddItem(123L, 5, 10.00M);
            var orderItem = order.Items.Last();

            Assert.Throws<ArgumentOutOfRangeException>(() => orderItem.DecreaseQuantity(0));
        }
    }
}
