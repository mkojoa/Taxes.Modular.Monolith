using Taxes.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Messaging.Outbox;

public interface IOutboxBroker
{
    bool Enabled { get; }
    Task SendAsync(params IMessage[] messages);
}