using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService{T1, T2, T3, T4, T5}"/>.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type of the service.</typeparam>
    /// <typeparam name="T2">Specifies the second type of the service.</typeparam>
    /// <typeparam name="T3">Specifies the third type of the service.</typeparam>
    /// <typeparam name="T4">Specifies the fourth type of the service.</typeparam>
    /// <typeparam name="T5">Specifies the fifth type of the service.</typeparam>
    public interface IServiceBuilder<T1, T2, T3, T4, T5> : IBuilder<IService<T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T1, T2, T3, T4, T5}"/> instance.</returns>
        IServiceBuilder<T1, T2, T3, T4, T5> AddSingleton<T>(string alias, T instance);
        /// <summary>
        /// Adds a singleton instance to the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder{T1, T2, T3, T4, T5}"/> instance.</returns>
        IServiceBuilder<T1, T2, T3, T4, T5> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4, T5> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T1, T2, T3, T4, T5> middleware);
        IServiceBuilder<T1, T2, T3, T4, T5> Use(IMiddleware<T1, T2, T3, T4, T5> middleware);
    }
}
