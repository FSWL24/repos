using AutoMapper;
using DataPoints.Persistence.Models;
using DataPoints.Types.InputTypes;
using DataPoints.Types.OutputTypes;


public class DataPointSubscriptionType
{
    [Subscribe]
    [Topic(nameof(OnDataPointUpdated))]
    public DataPointDictionaryOutput OnDataPointUpdated([EventMessage] DataPointDictionaryInput dataPointInput, [Service] IMapper mapper)
    {
        var dataPoint = dataPointInput as DataPointDictionary;
        return mapper.Map<DataPointDictionaryOutput>(dataPoint);
    }
}