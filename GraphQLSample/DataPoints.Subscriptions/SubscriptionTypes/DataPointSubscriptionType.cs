using AutoMapper;
using DataPoints.Persistence.Models;
using DataPoints.Types.InputTypes;
using DataPoints.Types.OutputTypes;

public class DataPointSubscriptionType
{
    private readonly IMapper _mapper;

    public DataPointSubscriptionType(IMapper mapper)
    {
        _mapper = mapper;
    }

    [Subscribe]
    [Topic(nameof(OnDataPointUpdated))]
    public DataPointDictionaryOutput OnDataPointUpdated([EventMessage] DataPointDictionaryInput dataPointInput)
    {
        var dataPoint = dataPointInput as DataPointDictionary;
        return _mapper.Map<DataPointDictionaryOutput>(dataPoint);
    }
}
