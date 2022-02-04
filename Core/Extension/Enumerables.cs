using System;
namespace Core.Extension
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableEx
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}

