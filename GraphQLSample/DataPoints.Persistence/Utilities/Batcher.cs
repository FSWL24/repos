using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Varasto.EntityFrameworkIBD.Utilities
{
    public static class Batcher
    {
        public delegate void AddOrUpdateRangeCallback(int offset, int step);
        public delegate Task AddOrUpdateRangeCallbackAsync(int offset, int step);

        public static void ByBatches(int total, int step, AddOrUpdateRangeCallback fn)
        {
            int count = total;
            int offset = 0;
            while (total > 0)
            {
                if (offset + step > count)
                    step = (count - offset);

                // Execute method
                fn(offset, step);

                offset += step;
                total -= step;
            }
        }

        public static async Task ByBatchesAsync(int total, int step, AddOrUpdateRangeCallbackAsync fn)
        {
            int count = total;
            int offset = 0;
            while (total > 0)
            {
                if (offset + step > count)
                    step = (count - offset);

                // Execute method
                await fn(offset, step);

                offset += step;
                total -= step;
            }
        }
    }
}
