using System;
using NUnit.Framework;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Domain.UnitTests
{
    public class CustomerTests
    {
        [Test]
        public void Create_WithValidNameAndEmail_CreatesCustomer()
        {
            var name = "Mohammad";
            var email = "m@example.com";

            
            var customer = Customer.Create(name, email);

            
            Assert.That(customer.Name, Is.EqualTo(name));
            Assert.That(customer.Email.ToString(), Is.EqualTo(email));
        }

        [Test]
        public void Create_WithNullName_ThrowsException()
        {
            
            string name = null!;
            var email = "m@example.com";

            
            Assert.Throws<ArgumentNullException>(() => Customer.Create(name, email));
        }

        [Test]
        public void Create_WithEmptyName_ThrowsException()
        {
            
            var name = "";
            var email = "m@example.com";

            
            Assert.Throws<ArgumentNullException>(() => Customer.Create(name, email));
        }

        [Test]
        public void Create_WithWhitespaceOnlyName_ThrowsException()
        {
            
            var name = "   ";
            var email = "john.doe@example.com";

            
            Assert.Throws<ArgumentNullException>(() => Customer.Create(name, email));
        }

        [Test]
        public void Create_WithNameTooLong_ThrowsException()
        {
            
            var name = new string('A', 501); // 501 characters
            var email = "m@example.com";

            Assert.Throws<ArgumentOutOfRangeException>(() => Customer.Create(name, email));
        }

        [Test]
        public void Create_WithNameAtMaxLength_Succeeds()
        {
            
            var name = new string('A', 500); // Exactly 500 characters
            var email = "m@example.com";

            
            var customer = Customer.Create(name, email);

            
            Assert.That(customer.Name, Is.EqualTo(name));
        }

        [Test]
        public void Create_WithInvalidEmail_ThrowsException()
        {
            
            var name = "John Doe";
            var email = "invalid-email";

            Assert.Throws<ArgumentException>(() => Customer.Create(name, email));
        }

        
    }
}
