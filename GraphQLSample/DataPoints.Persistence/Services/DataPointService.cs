using DataPoints.Persistence.Models;
using DataPoints.Persistence.Service.Common;
using DataPoints.Persistence.Services.Common;


namespace DataPoints.Mutations.MutationTypes
{

    public interface IDataPointsDictionaryService : IGenericService<DataPointsDictionary>
    {
    }

    public class DataPointsDictionaryService : GenericService<DataPointsDictionary>, IDataPointsDictionaryService
    {
        public DataPointsDictionaryService(IGenericRepository<DataPointsDictionary> genericRepository) : base(genericRepository)
        {
        }
    }

}
