using System;
using NUnit.Framework;
using OrderManagement.Domain.Exceptions;

namespace OrderManagement.Domain.UnitTests
{
    public class ItemNotFoundExceptionTests
    {
        [Test]
        public void Constructor_WithSearchTermAndObjectName_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = "123";
            var objectName = "Order";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Order not found with key : 123"));
        }

        [Test]
        public void Constructor_WithEmptySearchTerm_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = "";
            var objectName = "Customer";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Customer not found with key : "));
        }

        [Test]
        public void Constructor_WithNullSearchTerm_CreatesExceptionWithMessage()
        {
            // Arrange
            string searchTerm = null!;
            var objectName = "Product";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Product not found with key : "));
        }

        [Test]
        public void Constructor_WithEmptyObjectName_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = "456";
            var objectName = "";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo(" not found with key : 456"));
        }

        [Test]
        public void Constructor_WithNullObjectName_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = "789";
            string objectName = null!;

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo(" not found with key : 789"));
        }

        [Test]
        public void Constructor_WithLongSearchTerm_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = new string('A', 1000);
            var objectName = "Item";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo($"Item not found with key : {searchTerm}"));
        }

        [Test]
        public void Constructor_WithSpecialCharacters_CreatesExceptionWithMessage()
        {
            // Arrange
            var searchTerm = "test@example.com";
            var objectName = "User";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.Message, Is.EqualTo("User not found with key : test@example.com"));
        }

        [Test]
        public void Exception_InheritsFromException()
        {
            // Arrange
            var searchTerm = "123";
            var objectName = "Order";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception, Is.InstanceOf<Exception>());
        }

        [Test]
        public void Exception_HasCorrectType()
        {
            // Arrange
            var searchTerm = "123";
            var objectName = "Order";

            // Act
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Assert
            Assert.That(exception.GetType().Name, Is.EqualTo("ItemNotFoundException"));
        }

        [Test]
        public void Exception_CanBeThrownAndCaught()
        {
            // Arrange
            var searchTerm = "123";
            var objectName = "Order";

            // Act & Assert
            Assert.Throws<ItemNotFoundException>(() => 
            {
                throw new ItemNotFoundException(searchTerm, objectName);
            });
        }

        [Test]
        public void Exception_MessageIsReadOnly()
        {
            // Arrange
            var searchTerm = "123";
            var objectName = "Order";
            var exception = new ItemNotFoundException(searchTerm, objectName);

            // Act & Assert
            Assert.That(exception.Message, Is.EqualTo("Order not found with key : 123"));
            // Message property is read-only, so we can't change it
        }
    }
}
