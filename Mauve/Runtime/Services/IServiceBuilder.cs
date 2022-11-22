using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService"/>.
    /// </summary>
    public interface IServiceBuilder : IBuilder<IService>
    {
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder"/> instance.</returns>
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddSingleton<T>(T instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        void Run(IMiddleware middleware);
        IServiceBuilder Use(IMiddleware middleware);
    }
}
