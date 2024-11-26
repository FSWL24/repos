using DataPoints.Queries.QueryTypes;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPoints.Queries.Extensions
{
    public static class QueryTypesCollectionExtensions
    {
        public static IRequestExecutorBuilder AddQueryTypes(this IRequestExecutorBuilder builder)
        {
            builder
                .AddQueryType<DictionaryQueryType>();
                
            return builder;
        }
    }
}
