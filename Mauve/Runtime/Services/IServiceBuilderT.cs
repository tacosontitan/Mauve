using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService{T}"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the type of the service.</typeparam>
    public interface IServiceBuilder<T> : IBuilder<IService<T>>
    {
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T}"/> instance.</returns>
        IServiceBuilder<T> AddSingleton<TIn>(string alias, TIn instance);
        /// <summary>
        /// Adds a singleton instance to the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T}"/> instance.</returns>
        IServiceBuilder<T> AddSingleton<TIn>(TIn instance);
        void Run(IMiddleware<T> middleware);
        IServiceBuilder<T> Use(IMiddleware<T> middleware);
    }
}
