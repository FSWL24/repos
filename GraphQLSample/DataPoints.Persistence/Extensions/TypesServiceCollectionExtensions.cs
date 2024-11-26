
using DataPoints.Mutations.MutationTypes;
using Microsoft.Extensions.DependencyInjection;
using DataPoints.Persistence.Services.Common;
using DataPoints.Persistence.Service.Common;
using DataPoints.Persistence.Context;

namespace DataPoints.Types.Extensions
{
    public static  class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();
            services.AddSingleton<IDataPointsDictionaryService, DataPointsDictionaryService>();
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));
            return services;
        }
    }
}
