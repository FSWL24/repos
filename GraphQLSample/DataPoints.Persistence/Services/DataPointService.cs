using DataPoints.Persistence.Models;
using DataPoints.Persistence.Service.Common;
using DataPoints.Persistence.Services.Common;
using HotChocolate.Subscriptions;


namespace DataPoints.Mutations.MutationTypes
{

    public interface IDataPointsDictionaryService : IGenericService<DataPointDictionary>
    {
    }

    public class DataPointsDictionaryService : GenericService<DataPointDictionary>, IDataPointsDictionaryService
    {
        public DataPointsDictionaryService(IGenericRepository<DataPointDictionary> genericRepository, ITopicEventSender topicEventSender) : base(genericRepository, topicEventSender)
        {
        }
    }

}
