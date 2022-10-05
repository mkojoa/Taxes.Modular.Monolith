using Taxes.Shared.Abstractions.Kernel.Exceptions;
using System;

namespace Taxes.Shared.Abstractions.Kernel.ValueObjects
{
    public class Note : IEquatable<Note>
    {
        public string Value { get; }

        public Note(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (value.Length is > 500)
            {
                throw new InvalidNoteException(value);
            }

            Value = value;
        }

        public static implicit operator Note(string value) => value is null ? null : new Note(value);

        public static implicit operator string(Note value) => value?.Value;

        public bool Equals(Note other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Note)obj);
        }

        public override int GetHashCode() => Value is not null ? Value.GetHashCode() : 0;

        public override string ToString() => Value;
    }
}