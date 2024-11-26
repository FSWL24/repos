using System;
using System.Collections.Generic;
using System.Text;

namespace Varasto.EntityFrameworkIBD.Utilities
{
    public class AddAndUpdateHelper
    {
        public static void GetAddsAndUpdates<T, U>(
            Dictionary<U, T> incomingDtos,
            HashSet<U> foundKeys,
            out List<T> toAdd,
            out List<T> toUpdate)
        {
            toAdd = new List<T>();
            toUpdate = new List<T>();

            foreach (var dto in incomingDtos)
            {
                if (foundKeys.Contains(dto.Key))
                    toUpdate.Add(dto.Value);
                else
                    toAdd.Add(dto.Value);
            }
        }
    }
}
