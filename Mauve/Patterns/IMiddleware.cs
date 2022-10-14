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
        Task InvokeAsync(MiddlewareDelegate next);
    }
}
