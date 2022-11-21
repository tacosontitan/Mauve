using System.Threading;
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
        void Invoke(T input, MiddlewareDelegate<T> next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="input">The input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(T input, MiddlewareDelegate<T> next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="input">The input for the middleware.</param>
        /// <param name="next">The next middleware to utilize.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel asynchronous processing.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(T input, MiddlewareDelegate<T> next, CancellationToken cancellationToken);
    }
}
