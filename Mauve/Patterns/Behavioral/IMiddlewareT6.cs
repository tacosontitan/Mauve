using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> exposing methods for implementing middleware.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type utilized by the middleware.</typeparam>
    /// <typeparam name="T2">Specifies the second type utilized by the middleware.</typeparam>
    /// <typeparam name="T3">Specifies the third type utilized by the middleware.</typeparam>
    /// <typeparam name="T4">Specifies the fourth type utilized by the middleware.</typeparam>
    /// <typeparam name="T5">Specifies the fifth type utilized by the middleware.</typeparam>
    /// <typeparam name="T6">Specifies the sixth type utilized by the middleware.</typeparam>
    public interface IMiddleware<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t1">The first input for the middleware.</param>
        /// <param name="t2">The second input for the middleware.</param>
        /// <param name="t3">The third input for the middleware.</param>
        /// <param name="t4">The fourth input for the middleware.</param>
        /// <param name="t5">The fifth input for the middleware.</param>
        /// <param name="t6">The sixth input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        void Invoke(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, MiddlewareDelegate<T1, T2, T3, T4, T5, T6> next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t1">The first input for the middleware.</param>
        /// <param name="t2">The second input for the middleware.</param>
        /// <param name="t3">The third input for the middleware.</param>
        /// <param name="t4">The fourth input for the middleware.</param>
        /// <param name="t5">The fifth input for the middleware.</param>
        /// <param name="t6">The sixth input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, MiddlewareDelegate<T1, T2, T3, T4, T5, T6> next);
    }
}
