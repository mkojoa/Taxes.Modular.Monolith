using System;

namespace Taxes.Shared.Abstractions.Time;

public interface IClock
{
    DateTime CurrentDate();
}