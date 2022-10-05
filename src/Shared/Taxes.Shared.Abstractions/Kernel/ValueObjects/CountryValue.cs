using Taxes.Shared.Abstractions.Kernel.Entites;
using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Taxes.Shared.Abstractions.Kernel.ValueObjects
{
    public class CountryValue : IEquatable<CountryValue>
    {
        private static readonly HashSet<string> AllowedValues 
            = new HashSet<string>(GenericData.Countries.Select(x => x.Code.ToString()).ToArray());


        public string Value { get; }

        public CountryValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidCountryException(value);
            }

            value = value.ToUpperInvariant();
            if (!AllowedValues.Contains(value))
            {
                throw new UnsupportedCountryException(value);
            }

            Value = value;
        }

        public static implicit operator CountryValue(string value) => value is null ? null : new CountryValue(value);

        public static implicit operator string(CountryValue value) => value?.Value;

        public bool Equals(CountryValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CountryValue)obj);
        }

        public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

        public override string ToString() => Value;
    }
}