using System;
using System.Threading.Tasks;

namespace Taxes.Shared.Infrastructure.Messaging.Outbox;

public interface IInbox
{
    public bool Enabled { get; }
    Task HandleAsync(Guid messageId, string name, Func<Task> handler);
    Task CleanupAsync(DateTime? to = null);
}