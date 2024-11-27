using DataPoints.Mutations.Extensions;
using DataPoints.Persistence.Context;
using DataPoints.Persistence.Extensions;
using DataPoints.Persistence.Service.Common;
using HotChocolate.Subscriptions;

using Varasto.EntityFrameworkIBD.Utilities;

namespace DataPoints.Persistence.Services.Common
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly ITopicEventSender _eventSender;

        IGenericRepository<TEntity> _repository;
        private readonly int MAXBATCHSIZE = 500;

        public GenericService(IGenericRepository<TEntity> repository, ITopicEventSender topicEventSender)
        {
            _repository = repository;
            _eventSender = topicEventSender;
            AppDbContext.EntityChanged += async (entity, state) =>
            {
                if (entity != null)
                { 
                    var topic = entity.GetTopicName(state);
                    await _eventSender.SendAsync(topic, entity);
                }
            };
        }
        

        #region ADD/UPDATE Methods
        public async Task AddOrUpdateAsync(TEntity entity)
        {
            var existingEntity = await GetAsync(entity);
            if (existingEntity != null)
            {
                existingEntity.UpdateWithInput(entity);
                await _repository.UpdateAsync(existingEntity);
            }
            else
            {
                await _repository.AddAsync(entity);
            }
        }

        public async Task AddOrUpdateAsync(List<TEntity> entities, int? batchSize = null)
        {
            CalculateBatchSize(ref batchSize);

            await Batcher.ByBatchesAsync(entities.Count(), batchSize.Value, async (offset, step) =>
            {
                List<TEntity> entitiesForInsert = new List<TEntity>();
                List<TEntity> entitiesForUpdate = new List<TEntity>();

                var batch = entities.GetRange(offset, step);

                // Get key values from the batch of entities
                var keyValuesList = batch.Select(entity => entity.GetKeyValues(_repository)).ToList();

                // Fetch all existing entities in a single query using the primary keys 
                var existingEntities = await _repository.GetAsync(keyValuesList);

                // Create a lookup dictionary
                var entityLookup = existingEntities.ToDictionary(
                    entity => entity.GetKeyValues(_repository)
                    , entity => entity
                    , new ObjectArrayEqualityComparer());
                foreach (var entity in batch)
                {
                    var keyValues = entity.GetKeyValues(_repository);
                    if (entityLookup.TryGetValue(keyValues, out var existingEntity))
                    {
                        entitiesForUpdate.Add(existingEntity);
                    }
                    else
                    {
                        entitiesForInsert.Add(entity);
                    }
                }

                await _repository.AddRangeAsync(entitiesForInsert);
                await _repository.UpdateRangeAsync(entitiesForUpdate);
            });
        }

        #endregion

        #region DELETE Methods
        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var existingEntity = await GetAsync(entity);
            if (existingEntity != null)
            {
                await _repository.DeleteAsync(existingEntity);
            }
        }

        public async Task DeleteAsync(List<TEntity> entities, int? batchSize = null)
        {
            CalculateBatchSize(ref batchSize);

            await Batcher.ByBatchesAsync(entities.Count(), batchSize.Value, async (offset, step) =>
            {
                List<TEntity> entitiesForDelete = new List<TEntity>();
                var batch = entities.GetRange(offset, step);

                // Get key values from the batch of entities
                var keyValuesList = batch.Select(entity => entity.GetKeyValues(_repository)).ToList();

                // Fetch all existing entities in a single query using the primary keys 
                var existingEntities = await _repository.GetAsync(keyValuesList);

                // Create a lookup dictionary
                var entityLookup = existingEntities.ToDictionary(
                    entity => entity.GetKeyValues(_repository)
                    , entity => entity
                    , new ObjectArrayEqualityComparer());

                foreach (var entity in batch)
                {
                    var keyValues = entity.GetKeyValues(_repository);
                    if (entityLookup.TryGetValue(keyValues, out var existingEntity))
                    {
                        entitiesForDelete.Add(existingEntity);
                    }
                }
                await _repository.DeleteRangeAsync(entitiesForDelete);
            });
        }
        #endregion

        #region GET Methods
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(TEntity entity) 
        {
            var keyValues = entity.GetKeyValues(_repository);
            return await _repository.GetAsync(keyValues);
        }
        #endregion

        #region Private Methods
        

        private void CalculateBatchSize(ref int? batchSize)
        {
            //Limit the batch size to avoid performance issues with large data sets
            if (batchSize != null)
            {
                batchSize = batchSize > MAXBATCHSIZE ? MAXBATCHSIZE : batchSize;
            }
            else
            {
                batchSize = MAXBATCHSIZE;
            }
        }
        #endregion
    }
}
