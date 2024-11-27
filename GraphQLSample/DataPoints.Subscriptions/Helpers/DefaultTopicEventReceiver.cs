using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace DataPoints.Subscriptions.Helper
{
    public class DefaultTopicEventReceiver : ITopicEventReceiver
    {
        public ValueTask<ISourceStream<TMessage>> SubscribeAsync<TMessage>(string topicName, CancellationToken cancellationToken = default)
        {
            return new ValueTask<ISourceStream<TMessage>>();
        }

        public ValueTask<ISourceStream<TMessage>> SubscribeAsync<TMessage>(string topicName, int? bufferCapacity, TopicBufferFullMode? bufferFullMode, CancellationToken cancellationToken = default)
        {
            return new ValueTask<ISourceStream<TMessage>>();
        }
    }
}
