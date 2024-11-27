using HotChocolate.Subscriptions;

namespace DataPoints.Subscriptions.Helper
{
    public class DefaultTopicEventSender : ITopicEventSender
    {
        public ValueTask CompleteAsync(string topicName)
        {
            return ValueTask.CompletedTask;
        }

        ValueTask ITopicEventSender.SendAsync<TMessage>(string topicName, TMessage message, CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }
    }
}
