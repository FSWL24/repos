using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace DataPoints.Subscriptions.Helper
{
    public class DefaultTopicEventReceiver : ITopicEventReceiver
    {
        private readonly ConcurrentDictionary<string, Channel<object>> _topics = new();

        public ValueTask<ISourceStream<TMessage>> SubscribeAsync<TMessage>(string topicName, CancellationToken cancellationToken = default)
        {
            var channel = _topics.GetOrAdd(topicName, _ => Channel.CreateUnbounded<object>());
            var stream = new SourceStream(channel.Reader.ReadAllAsync(cancellationToken));
            return new ValueTask<ISourceStream<TMessage>>((ISourceStream<TMessage>)stream);
        }

        public ValueTask<ISourceStream<TMessage>> SubscribeAsync<TMessage>(string topicName, int? bufferCapacity, TopicBufferFullMode? bufferFullMode, CancellationToken cancellationToken = default)
        {
            var channel = _topics.GetOrAdd(topicName, _ => Channel.CreateUnbounded<object>());
            var stream = new SourceStream(channel.Reader.ReadAllAsync(cancellationToken));
            return new ValueTask<ISourceStream<TMessage>>((ISourceStream<TMessage>)stream);
        }
    }

    public class SourceStream : ISourceStream<object>
    {
        private readonly IAsyncEnumerable<object> _enumerable;

        public SourceStream(IAsyncEnumerable<object> enumerable)
        {
            _enumerable = enumerable;
        }

        public IAsyncEnumerable<object> ReadEventsAsync()
        {
            return _enumerable;
        }

        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }

        IAsyncEnumerable<object?> ISourceStream.ReadEventsAsync()
        {
            return _enumerable;
        }
    }
}
