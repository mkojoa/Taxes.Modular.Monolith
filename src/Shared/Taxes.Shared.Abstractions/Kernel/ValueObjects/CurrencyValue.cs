using Taxes.Shared.Abstractions.Kernel.Entites;
using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Taxes.Shared.Abstractions.Kernel.ValueObjects;

public class CurrencyValue : IEquatable<CurrencyValue>
{
    private static readonly HashSet<string> AllowedValues = new HashSet<string>(GenericData.Currencies.Select(x => x.Code.ToString()).ToArray());

    public string Value { get; }

    public CurrencyValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
        {
            throw new InvalidCurrencyException(value);
        }

        value = value.ToUpperInvariant();
        if (!AllowedValues.Contains(value))
        {
            throw new UnsupportedCurrencyException(value);
        }

        Value = value;
    }

    public static implicit operator CurrencyValue(string value) => new(value);

    public static implicit operator string(CurrencyValue value) => value.Value;

    public static bool operator ==(CurrencyValue a, CurrencyValue b)
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

    public static bool operator !=(CurrencyValue a, CurrencyValue b) => !(a == b);

    public bool Equals(CurrencyValue other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((CurrencyValue)obj);
    }

    public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

    public override string ToString() => Value;
}