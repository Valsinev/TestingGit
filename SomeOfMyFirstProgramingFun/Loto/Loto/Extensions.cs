
namespace Loto
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
