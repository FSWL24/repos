using AutoMapper;
using DataPoints.Persistence.Models;
using DataPoints.Types.OutputTypes;

namespace DataPoints.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataPointsDictionary, DataPointDictionaryOutput>();
        }
    }
}
