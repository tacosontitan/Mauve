using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService{T1, T2, T3, T4}"/>.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type of the service.</typeparam>
    /// <typeparam name="T2">Specifies the second type of the service.</typeparam>
    /// <typeparam name="T3">Specifies the third type of the service.</typeparam>
    /// <typeparam name="T4">Specifies the fourth type of the service.</typeparam>
    public interface IServiceBuilder<T1, T2, T3, T4> : IBuilder<IService<T1, T2, T3, T4>>
    {
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T1, T2, T3, T4}"/> instance.</returns>
        IServiceBuilder<T1, T2, T3, T4> AddSingleton<T>(string alias, T instance);
        /// <summary>
        /// Adds a singleton instance to the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T1, T2, T3, T4}"/> instance.</returns>
        IServiceBuilder<T1, T2, T3, T4> AddSingleton<T>(T instance);
        void Run(IMiddleware<T1, T2, T3, T4> middleware);
        IServiceBuilder<T1, T2, T3, T4> Use(IMiddleware<T1, T2, T3, T4> middleware);
    }
}
