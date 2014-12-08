using System;
using System.Collections.Generic;

namespace Xenon.Core
{
    /// <summary>
    /// Extensions for <see cref="IEnumerable{T}"/>s
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <typeparam name="TInput"></typeparam>
        public static void ForEach<TInput>(this IEnumerable<TInput> source, Action<TInput> action)
        {
            foreach (var input in source)
                action.Execute(input);
        }
    }
}
