
using AutoMapper;
using DataPoints.Mutations.MutationTypes;
using DataPoints.Types.OutputTypes;

namespace DataPoints.Queries.QueryTypes
{
    public class DictionaryQueryType
    {
        private IDataPointsDictionaryService _service;
        private readonly IMapper _mapper;

        public DictionaryQueryType(IDataPointsDictionaryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DataPointDictionaryOutput>> GetDataPoints()
        {
            var result = await _service.GetAllAsync();
            return _mapper.Map<IEnumerable<DataPointDictionaryOutput>>(result);
        }
    }
}
