using DataPoints.Types.InputTypes;

namespace DataPoints.Mutations.MutationTypes
{
    
    public class DataPointMutationType
    {
       

        public async Task UpsertDataPointAsync(DataPointDictionaryInput input, [Service] IDataPointsDictionaryService _service)
        {
            await _service.AddOrUpdateAsync(input);
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
