using DataPoints.Persistence.Services.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataPoints.Persistence.Extensions
{
    public static  class EntityExtensions
    {
        public static string GetTopicName<TEntity>(this TEntity entity, EntityState state)
        {
            Type type = entity.GetType();   
            return $"{type.Name}_{state}";
        }

        public static object[] GetKeyValues<TEntity>(this TEntity model, IGenericRepository<TEntity> repository) where TEntity : class 
        {
            var propertiesName = repository.GetKeys<TEntity>();
            List<object> values = new List<object>();
            foreach (var propertyName in propertiesName)
            {
                PropertyInfo property = model!.GetType().GetProperty(propertyName)!;
                if (property != null)
                {
                    var value = property.GetValue(model, null);
                    if (value != null)
                    {
                        values.Add(value);
                    }
                }
            }
            return values.ToArray();
        }
    }
}
