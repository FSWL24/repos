using DataPoints.Mutations.MutationTypes;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPoints.Mutations.Extensions
{
    public static  class MutationTypesCollectionExtensions
    {
        public static IRequestExecutorBuilder AddMutationTypes(this IRequestExecutorBuilder builder)
        {
            builder.AddMutationType<DataPointMutationType>();
            return builder;
        }
    }
}
