using System;

namespace Xenon.Core
{
    /// <summary>
    /// Extension methods for monadic operators
    /// </summary>
    public static class Monad
    {
        /// <summary>
        /// Executes a <see cref="Action"/>
        /// </summary>
        /// <param name="action"></param>
        public static void Execute(this Action action)
        {
            if (action != null)
                action();
        }

        /// <summary>
        /// Executes a <see cref="Action{T}"/>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="input"></param>
        /// <typeparam name="TInput"></typeparam>
        public static void Execute<TInput>(this Action<TInput> action, TInput input)
        {
            if (action != null)
                action(input);
        }

        /// <summary>
        /// Executes a <see cref="Func{T,TResult}"/>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="input"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        public static TOutput Execute<TInput, TOutput>(this Func<TInput, TOutput> action, TInput input)
        {
            var output = default(TOutput);
            if (action != null)
                output = action(input);

            return output;
        }
    }
}