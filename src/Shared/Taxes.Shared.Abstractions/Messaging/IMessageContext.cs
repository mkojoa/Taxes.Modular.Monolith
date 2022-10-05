using Taxes.Shared.Abstractions.Contexts;
using System;

namespace Taxes.Shared.Abstractions.Messaging;

public interface IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }
}