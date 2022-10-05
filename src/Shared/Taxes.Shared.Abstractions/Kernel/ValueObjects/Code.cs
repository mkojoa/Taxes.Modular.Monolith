using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;


namespace Taxes.Shared.Abstractions.Kernel.ValueObjects
{
    public class Code : IEquatable<Code>
    {
        public string Value { get; }

        public Code(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 30)
            {
                throw new InvalidCodeException(value);
            }

            Value = value.Trim();
        }

        public static implicit operator Code(string value) => new Code(value);

        public static implicit operator string(Code value) => value?.Value;

        public bool Equals(Code other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Code)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}