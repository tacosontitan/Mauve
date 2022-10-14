using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> exposing methods for implementing middleware.
    /// </summary>
    /// <typeparam name="T">Specifies the first type utilized by the middleware.</typeparam>
    /// <typeparam name="U">Specifies the second type utilized by the middleware.</typeparam>
    public interface IMiddleware<T, U>
    {
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t">The first input for the middleware.</param>
        /// <param name="t">The second input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        void Invoke(T t, U u, MiddlewareDelegate<T, U> next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="t">The first input for the middleware.</param>
        /// <param name="t">The second input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        Task InvokeAsync(T t, U u, MiddlewareDelegate<T, U> next);
    }
}
