﻿using System.Threading;
using System.Threading.Tasks;

namespace Taxes.Shared.Abstractions.Events;

public interface IEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class, IEvent;
}