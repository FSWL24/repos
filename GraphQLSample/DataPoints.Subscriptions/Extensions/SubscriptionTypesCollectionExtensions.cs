using HotChocolate.Execution.Configuration;

namespace DataPoints.Mutations.Extensions
{
    public static  class SubscriptionsTypesCollectionExtensions
    {
        public static IRequestExecutorBuilder AddSubscriptionTypes(this IRequestExecutorBuilder builder)
        {
            return builder;
        }
    }
}
