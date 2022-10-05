using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Taxes.Shared.Abstractions.Kernel.ValueObjects
{
    public class Lang : IEquatable<Lang>
    {
        private static readonly HashSet<string> AllowedValues = new HashSet<string>() { "ENG","FR"};

        public string Value { get; }

        public Lang(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 5)
            {
                throw new InvalidLangException(value);
            }

            value = value.ToUpperInvariant();
            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedLangException(value);
            }

            Value = value;
        }

        public static implicit operator Lang(string value) => new(value);

        public static implicit operator string(Lang value) => value.Value;

        public static bool operator ==(Lang a, Lang b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is not null && b is not null)
            {
                return a.Value.Equals(b.Value);
            }

            return false;
        }

        public static bool operator !=(Lang a, Lang b) => !(a == b);

        public bool Equals(Lang other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Lang)obj);
        }

        public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

        public override string ToString() => Value;
    }
}