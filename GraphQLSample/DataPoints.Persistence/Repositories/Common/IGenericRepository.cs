namespace DataPoints.Persistence.Services.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<T> GetAsync(object[] keyValues);
        Task<IEnumerable<T>> GetAsync(List<object[]> keyValuesList);
        Task<IEnumerable<T>> GetAllAsync();
        List<string> GetKeys<TEntityType>();
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
    }
}
