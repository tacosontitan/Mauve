using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> exposing methods for implementing middleware.
    /// </summary>
    /// <typeparam name="T">Specifies the first type utilized by the middleware.</typeparam>
    /// <typeparam name="U">Specifies the second type utilized by the middleware.</typeparam>
    /// <typeparam name="V">Specifies the third type utilized by the middleware.</typeparam>
    public interface IMiddleware<T, U, V>
    {
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t">The first input for the middleware.</param>
        /// <param name="u">The second input for the middleware.</param>
        /// <param name="v">The third input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        void Invoke(T t, U u, V v, MiddlewareDelegate<T, U, V> next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t">The first input for the middleware.</param>
        /// <param name="u">The second input for the middleware.</param>
        /// <param name="v">The third input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(T t, U u, V v, MiddlewareDelegate<T, U, V> next);
    }
}
