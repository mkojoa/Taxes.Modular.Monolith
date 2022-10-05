using Taxes.Shared.Abstractions.Kernel.ValueObjects;
using System;

namespace Taxes.Shared.Abstractions.Kernel.Entites
{
    public class Segment
    {
        public Code Code { get; set; }
        public Name Name { get; set; }
    }
}
