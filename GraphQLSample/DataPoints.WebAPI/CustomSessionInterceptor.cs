using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore.Subscriptions.Protocols;
using HotChocolate.Execution;
// Add this class
public class CustomSessionInterceptor : ISocketSessionInterceptor
{
    public ValueTask OnCloseAsync(ISocketSession session, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask OnCompleteAsync(ISocketSession session, string operationSessionId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ConnectionStatus> OnConnectAsync(ISocketSession session, IOperationMessagePayload connectionInitMessage, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IReadOnlyDictionary<string, object?>?> OnPingAsync(ISocketSession session, IOperationMessagePayload pingMessage, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask OnPongAsync(ISocketSession session, IOperationMessagePayload pongMessage, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask OnRequestAsync(ISocketSession session, string operationSessionId, OperationRequestBuilder requestBuilder, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IOperationResult> OnResultAsync(ISocketSession session, string operationSessionId, IOperationResult result, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
