using DataPoints.Subscriptions.Helper;
using HotChocolate.Execution.Configuration;
using HotChocolate.Subscriptions;
using Microsoft.Extensions.DependencyInjection;

namespace DataPoints.Mutations.Extensions
{
    public static  class SubscriptionsTypesCollectionExtensions
    {
        public static IRequestExecutorBuilder AddSubscriptionTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddSubscriptionType<DataPointSubscriptionType>();
            
            
            return builder;
        }
    }
}
