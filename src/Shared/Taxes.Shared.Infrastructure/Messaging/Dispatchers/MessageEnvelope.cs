using Taxes.Shared.Abstractions.Messaging;

namespace Taxes.Shared.Infrastructure.Messaging.Dispatchers;

internal record MessageEnvelope(IMessage Message, IMessageContext MessageContext);