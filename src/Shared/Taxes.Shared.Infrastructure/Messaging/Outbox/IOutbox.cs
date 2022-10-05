using Taxes.Shared.Abstractions.Messaging;
using System;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Messaging.Outbox;

public interface IOutbox
{
    bool Enabled { get; }
    Task SaveAsync(params IMessage[] messages);
    Task PublishUnsentAsync();
    Task CleanupAsync(DateTime? to = null);
}