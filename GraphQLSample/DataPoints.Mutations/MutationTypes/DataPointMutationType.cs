using DataPoints.Types.InputTypes;

namespace DataPoints.Mutations.MutationTypes
{
    public class DataPointMutationType
    {
        private readonly IDataPointsDictionaryService _service;

        public DataPointMutationType(IDataPointsDictionaryService service)
        {
            _service = service;
        }

        public async Task UpsertDataPointAsync(DataPointDictionaryInput input)
        {
            await _service.AddOrUpdateAsync(input);
        }

        public async Task<bool> DeleteDataPointAsync(DataPointDictionaryInput input)
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
