
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data utilized in requests to this service.</typeparam>
    public interface IService<T>
    {
        /// <summary>
        /// A collection of dependencies for the service.
        /// </summary>
        IDependencyCollection Dependencies { get; set; }
        /// <summary>
        /// The middleware delegate the service runs requests through.
        /// </summary>
        MiddlewareDelegate<T> MiddlewareDelegate { get; set; }
    }
}
