using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> exposing methods for implementing middleware.
    /// </summary>
    public interface IMiddleware
    {
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="next">The next middleware to utilize.</param>
        void Invoke(MiddlewareDelegate next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="next">The next middleware to utilize.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(MiddlewareDelegate next);
        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="next">The next middleware to utilize.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel asynchronous processing.</param>
        /// <returns>A <see cref="Task"/> describing the result of the invocation.</returns>
        Task InvokeAsync(MiddlewareDelegate next, CancellationToken cancellationToken);
    }
}
