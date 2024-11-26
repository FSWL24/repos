using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DataPoints.Persistence.Context;
using LinqKit;

namespace DataPoints.Persistence.Services.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        #region ADD Methods
        public async Task AddAsync(T entity)
        {

            _context.Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region DELETE Methods
        public async Task DeleteAsync(T entity)
        {

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {

            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region GET Methods
        public async Task<T> GetAsync(object[] keyValues)
        {

            return await _context.FindAsync<T>(keyValues);

        }

        public async Task<IEnumerable<T>> GetAsync(List<object[]> keyValuesList)
        {

            var dbSet = _context.Set<T>();
            var keyProperties = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;

            IQueryable<T> query = dbSet;

            // Build the predicate for each set of key values
            var predicates = keyValuesList.Select(keyValues =>
            {
                var predicate = PredicateBuilder.New<T>(true);
                for (int i = 0; i < keyProperties.Count; i++)
                {
                    var keyProperty = keyProperties[i];
                    var keyValue = keyValues[i];
                    var param = Expression.Parameter(typeof(T), "e");
                    predicate = predicate.And(Expression.Lambda<Func<T, bool>>(
                                Expression.Equal(Expression.Property(param, keyProperty.Name), Expression.Constant(keyValue)), param));
                }
                return predicate;
            });
            // Combine all predicates with OR
            var combinedPredicate = predicates.Aggregate(PredicateBuilder.New<T>(false), (current, predicate) => current.Or(predicate));
            // Apply the combined predicate to the query
            query = query.Where(combinedPredicate);
            return await query.ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            return await _context.Set<T>().AsNoTracking().ToListAsync();

        }

        public List<string> GetKeys<TEntityType>()
        {

            var props = _context.Model.FindEntityType(typeof(TEntityType)).FindPrimaryKey().Properties.Select(x => x.Name);
            return props.ToList();

        }
        #endregion

        #region UPDATE Methods
        public async Task UpdateAsync(T entity)
        {

            if (entity != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }

        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {

            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();

        }
        #endregion
    }
}
