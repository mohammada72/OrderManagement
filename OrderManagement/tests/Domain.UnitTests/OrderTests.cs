using System;
using Domain.Entities;
using Domain.ValueObjects;
using NUnit;
using NUnit.Framework;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.UnitTests
{
    public class OrderTests
    {
        [Test]
        public void New_order_is_draft_and_empty_total()
        {
            var order = new Order(new OrderId(Guid.NewGuid()));
            Assert.Equal("0.00 USD", order.Total.ToString());
        }

        [Fact]
        public void Add_item_increases_total()
        {
            var order = new Order(new OrderId(Guid.NewGuid()));
            order.AddItem(new decimal(Guid.NewGuid()), "Test", 2, new decimal(5m, "USD"));
            Assert.Equal("10.00 USD", order.Total.ToString());
        }

        [Fact]
        public void Checkout_non_empty_succeeds()
        {
            var order = new Order(new OrderId(Guid.NewGuid()));
            order.AddItem(new decimal(Guid.NewGuid()), "Test", 1, new decimal(3m, "USD"));
            order.Checkout();
        }

        [Fact]
        public void Checkout_empty_throws()
        {
            var order = new Order(new OrderId(Guid.NewGuid()));
            Assert.Throws<InvalidOperationException>(() => order.Checkout());
        }
    }
}
