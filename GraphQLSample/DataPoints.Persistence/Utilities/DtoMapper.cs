using System;
using System.Collections.Generic;
using System.Text;

namespace Varasto.EntityFrameworkIBD.Utilities
{
    public class DtoMapper
    {
        public static void MapIgnoreNulls<Dto, Entity>(Dto dto, ref Entity entity) where Dto : class where Entity : Dto
        {
            foreach(var property in typeof(Dto).GetProperties())
            {
                var value = property.GetValue(dto);
                if (value != null)
                {
                    var entityProperty = typeof(Entity).GetProperty(property.Name);
                    entityProperty.SetValue(entity, value);
                }
            }
        }
    }
}
