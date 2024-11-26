using System;
using System.Collections.Generic;
using System.Text;

namespace Varasto.EntityFrameworkIBD.Utilities
{
    public static class IEnumerableExtensions
    {
        // ToHashSet() is not included in NetStandard2.0 ????
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            return new HashSet<T>(source, comparer);
        }
    }
}
