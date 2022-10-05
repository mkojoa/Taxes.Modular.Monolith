using Taxes.Shared.Abstractions.Contexts;
using Taxes.Shared.Abstractions.Messaging;
using System;

namespace Taxes.Shared.Infrastructure.Messaging.Contexts;

public class MessageContext : IMessageContext
{
    public Guid MessageId { get; }
    public IContext Context { get; }

    public MessageContext(Guid messageId, IContext context)
    {
        MessageId = messageId;
        Context = context;
    }
}