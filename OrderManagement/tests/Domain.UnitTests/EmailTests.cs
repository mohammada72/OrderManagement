using System;
using NUnit.Framework;
using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Domain.UnitTests
{
    public class EmailTests
    {
        [Test]
        public void Constructor_WithValidEmail_CreatesEmail()
        {
            // Arrange
            var emailValue = "test@example.com";

            // Act
            var email = new Email(emailValue);

            // Assert
            Assert.That(email.ToString(), Is.EqualTo(emailValue));
        }

        [Test]
        public void Constructor_WithNullEmail_ThrowsException()
        {
            // Arrange
            string emailValue = null!;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Email(emailValue));
        }

        [Test]
        public void Constructor_WithEmptyEmail_ThrowsException()
        {
            // Arrange
            var emailValue = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Email(emailValue));
        }

        [Test]
        public void Constructor_WithWhitespaceOnlyEmail_ThrowsException()
        {
            // Arrange
            var emailValue = "   ";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Email(emailValue));
        }

        [Test]
        public void Constructor_WithEmailTooLong_ThrowsException()
        {
            // Arrange
            var emailValue = new string('a', 300) + "@example.com";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Email(emailValue));
        }

        [Test]
        public void Constructor_WithEmailAtMaxLength_Succeeds()
        {
            // Arrange
            var emailValue = new string('a', 282) + "@example.com";

            // Act
            var email = new Email(emailValue);

            // Assert
            Assert.That(email.ToString(), Is.EqualTo(emailValue));
        }

        [Test]
        public void Constructor_WithInvalidFormat_ThrowsException()
        {
            // Arrange
            var invalidEmails = new[]
            {
                "invalid-email",
                "@example.com",
                "test@",
                "test.example.com",
                "test@.com",
                "test@example.",
                "test@@example.com"
            };

            foreach (var invalidEmail in invalidEmails)
            {
                Assert.Throws<ArgumentException>(() => new Email(invalidEmail), 
                    $"Email '{invalidEmail}' should be invalid");
            }
        }

        [Test]
        public void Constructor_WithValidFormats_Succeeds()
        {
            // Arrange
            var validEmails = new[]
            {
                "test@example.com",
                "user.name@domain.co.uk",
                "firstname+lastname@example.com",
                "email@subdomain.example.com",
                "firstname-lastname@example.com",
                "1234567890@example.com",
                "email@example-one.com",
                "email@example.name",
                "email@example.museum",
                "email@example.co.jp",
                "firstname-lastname@example.com"
            };

            foreach (var validEmail in validEmails)
            {
                // Act & Assert
                Assert.DoesNotThrow(() => new Email(validEmail), 
                    $"Email '{validEmail}' should be valid");
            }
        }

        [Test]
        public void IsValidEmail_WithValidEmail_ReturnsTrue()
        {
            // Arrange
            var emailValue = "test@example.com";

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void IsValidEmail_WithInvalidEmail_ReturnsFalse()
        {
            // Arrange
            var emailValue = "invalid-email";

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidEmail_WithNullEmail_ReturnsFalse()
        {
            // Arrange
            string emailValue = null!;

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidEmail_WithEmptyEmail_ReturnsFalse()
        {
            // Arrange
            var emailValue = "";

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidEmail_WithWhitespaceEmail_ReturnsFalse()
        {
            // Arrange
            var emailValue = "   ";

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidEmail_WithEmailTooLong_ReturnsFalse()
        {
            // Arrange
            var emailValue = new string('a', 300) + "@example.com";

            // Act
            var isValid = Email.IsValidEmail(emailValue);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void ImplicitOperator_FromString_CreatesEmail()
        {
            // Arrange
            var emailValue = "test@example.com";

            // Act
            Email email = emailValue;

            // Assert
            Assert.That(email.ToString(), Is.EqualTo(emailValue));
        }

        [Test]
        public void ImplicitOperator_ToString_ReturnsString()
        {
            // Arrange
            var email = new Email("test@example.com");

            // Act
            string emailString = email;

            // Assert
            Assert.That(emailString, Is.EqualTo("test@example.com"));
        }

        [Test]
        public void Equals_WithSameEmail_ReturnsTrue()
        {
            // Arrange
            var email1 = new Email("test@example.com");
            var email2 = new Email("test@example.com");

            // Act & Assert
            Assert.That(email1, Is.EqualTo(email2));
            Assert.That(email1.Equals(email2), Is.True);
        }

        [Test]
        public void Equals_WithDifferentEmail_ReturnsFalse()
        {
            // Arrange
            var email1 = new Email("test1@example.com");
            var email2 = new Email("test2@example.com");

            // Act & Assert
            Assert.That(email1, Is.Not.EqualTo(email2));
            Assert.That(email1.Equals(email2), Is.False);
        }

        [Test]
        public void GetHashCode_WithSameEmail_ReturnsSameHashCode()
        {
            // Arrange
            var email1 = new Email("test@example.com");
            var email2 = new Email("test@example.com");

            // Act
            var hashCode1 = email1.GetHashCode();
            var hashCode2 = email2.GetHashCode();

            // Assert
            Assert.That(hashCode1, Is.EqualTo(hashCode2));
        }

        [Test]
        public void GetHashCode_WithDifferentEmail_ReturnsDifferentHashCode()
        {
            // Arrange
            var email1 = new Email("test1@example.com");
            var email2 = new Email("test2@example.com");

            // Act
            var hashCode1 = email1.GetHashCode();
            var hashCode2 = email2.GetHashCode();

            // Assert
            Assert.That(hashCode1, Is.Not.EqualTo(hashCode2));
        }

        [Test]
        public void ToString_ReturnsEmailValue()
        {
            // Arrange
            var emailValue = "test@example.com";
            var email = new Email(emailValue);

            // Act
            var result = email.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(emailValue));
        }
    }
}
