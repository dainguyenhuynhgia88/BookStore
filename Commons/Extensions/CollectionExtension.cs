using System.Collections.Generic;
using System.Linq;

namespace Commons.Extensions
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection == null || (collection != null && !collection.Any()))
            {
                return true;
            }

            return false;
        }
    }
}
