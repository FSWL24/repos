using AutoMapper;
using DataPoints.Persistence.Models;
using DataPoints.Types.InputTypes;
using DataPoints.Types.OutputTypes;
using HotChocolate.Subscriptions;

namespace DataPoints.Mutations.MutationTypes
{
    
    public class DataPointMutationType
    {
        public async Task<DataPointDictionaryOutput> UpsertDataPointAsync(DataPointDictionaryInput input, [Service] IDataPointsDictionaryService _service, [Service] IMapper mapper, [Service] ITopicEventSender sender)
        {
            await _service.AddOrUpdateAsync(input);
            var dataPoint = input as DataPointDictionary;
            await sender.SendAsync("OnDataPointUpdated", input);
            return mapper.Map<DataPointDictionaryOutput>(dataPoint);
        }

        public async Task<bool> DeleteDataPointAsync(DataPointDictionaryInput input, [Service] IDataPointsDictionaryService _service)
        {
            var dataPoint = await _service.GetAsync(input);
            if (dataPoint == null)
            {
                return false;
            }

            await _service.DeleteAsync(dataPoint);

            return true;
        }
    }
}
