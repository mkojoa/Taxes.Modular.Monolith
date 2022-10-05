using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;

namespace Taxes.Shared.Abstractions.Kernel.ValueObjects
{
    public class CompanyReference : IEquatable<CompanyReference>
    {
        public string Value { get; }

        public CompanyReference(string value)
        {
            if (value.Length > 30)
            {
                throw new InvalidCompanyReferenceException(value);
            }

            Value = value.Trim();
        }

        public static implicit operator CompanyReference(string value) => new CompanyReference(value);

        public static implicit operator string(CompanyReference value) => value?.Value;

        public bool Equals(CompanyReference other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CompanyReference)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value;
    }
}