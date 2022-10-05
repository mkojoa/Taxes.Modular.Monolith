using Taxes.Shared.Abstractions.Messaging;

namespace Taxes.Shared.Infrastructure.Messaging.Contexts;

public interface IMessageContextRegistry
{
    void Set(IMessage message, IMessageContext context);
}