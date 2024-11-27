using System.Reflection;

namespace DataPoints.Mutations.Extensions
{

    public static class UpdateEntityExtension
    {

        public static void UpdateWithInput<TEntity, TInput>(this TEntity entity, TInput input)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (input == null) throw new ArgumentNullException(nameof(input));

            var inputProperties = typeof(TInput).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var entityProperties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var inputProp in inputProperties)
            {
                var objectValue = inputProp.GetValue(input, null);
                if (objectValue is object || inputProp.PropertyType.IsGenericType && 
                    inputProp.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var entityProp = entityProperties.FirstOrDefault(p => p.Name == inputProp.Name);
                    if (entityProp != null && entityProp.CanWrite)
                    {
                        entityProp.SetValue(entity, objectValue);
                    }
                }
            }
        }
    }
}

