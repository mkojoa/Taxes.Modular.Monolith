using Taxes.Shared.Abstractions.Time;
using System;

namespace Taxes.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}