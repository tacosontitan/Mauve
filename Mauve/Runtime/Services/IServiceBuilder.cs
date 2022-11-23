using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService"/>.
    /// </summary>
    public interface IServiceBuilder
    {
        IServiceBuilder AddScoped<T>();
        IServiceBuilder AddScoped<T>(string alias);
        IServiceBuilder AddScoped<T>(IFactory<T> factory);
        IServiceBuilder AddScoped<T>(string alias, IFactory<T> factory);
        IServiceBuilder AddScoped<T>(Func<T> factory);
        IServiceBuilder AddScoped<T>(string alias, Func<T> factory);
        /// <summary>
        /// Adds a singleton instance to the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder"/> instance.</returns>
        IServiceBuilder AddSingleton<T>(T instance);
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceBuilder"/> instance.</returns>
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddTransient<T>();
        IServiceBuilder AddTransient<T>(string alias);
        IServiceBuilder AddTransient<T>(IFactory<T> factory);
        IServiceBuilder AddTransient<T>(string alias, IFactory<T> factory);
        IServiceBuilder AddTransient<T>(Func<T> factory);
        IServiceBuilder AddTransient<T>(string alias, Func<T> factory);
    }
}
