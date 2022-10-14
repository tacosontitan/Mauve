using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> exposing methods for implementing middleware.
    /// </summary>
    /// <typeparam name="T">Specifies the type utilized by the middleware.</typeparam>
    public interface IMiddleware<T>
    {
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="input">The input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        Task InvokeAsync(T input, MiddlewareDelegate<T> next);
    }
}
