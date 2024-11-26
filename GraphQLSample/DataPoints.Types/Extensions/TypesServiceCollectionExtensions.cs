using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPoints.Types.Extensions
{
    public static  class TypesServiceCollectionExtensions
    {
        public static IRequestExecutorBuilder AddDataPointTypes(this IRequestExecutorBuilder builder)
        {
            builder
                .AddType<DataPointsDictionaryType>();

            return builder;
        }
    }
}
