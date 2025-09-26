using System.Text.RegularExpressions;

namespace OrderManagement.Domain.ValueObjects
{
    public record Email : IEquatable<Email>
    {
        private readonly string _value;

        public Email(string value)
        {
            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format", nameof(value));

            _value = value;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static implicit operator Email(string value) => new(value);

        public static implicit operator string(Email email) => email._value;

        public override string ToString() => _value;

    }
}
