
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// A collection of dependencies for the service.
        /// </summary>
        IDependencyCollection Dependencies { get; set; }
        /// <summary>
        /// The middleware delegate the service runs requests through.
        /// </summary>
        MiddlewareDelegate MiddlewareDelegate { get; set; }
    }
}
