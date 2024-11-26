namespace DataPoints.Persistence.Service.Common
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task AddOrUpdateAsync(TEntity entity);
        Task AddOrUpdateAsync(List<TEntity> entities, int? batchSize = null);

        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(List<TEntity> entities, int? batchSize = null);

        Task<TEntity> GetAsync(TEntity entity);
      
        Task<IEnumerable<TEntity>> GetAllAsync();
        
    }
}
