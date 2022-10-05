using Taxes.Shared.Abstractions.Exceptions;
using System;

namespace Taxes.Shared.Infrastructure.Exceptions;

public interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}