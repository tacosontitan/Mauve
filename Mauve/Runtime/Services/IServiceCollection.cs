using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService"/>.
    /// </summary>
    public interface IServiceCollection
    {
        IServiceCollection AddScoped<T>();
        IServiceCollection AddScoped<T>(string alias);
        IServiceCollection AddScoped<T>(IFactory<T> factory);
        IServiceCollection AddScoped<T>(string alias, IFactory<T> factory);
        IServiceCollection AddScoped<T>(Func<T> factory);
        IServiceCollection AddScoped<T>(string alias, Func<T> factory);
        /// <summary>
        /// Adds a singleton instance to the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceCollection"/> instance.</returns>
        IServiceCollection AddSingleton<T>(T instance);
        /// <summary>
        /// Adds a singleton instance to the service using the specified alias.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the singleton.</typeparam>
        /// <param name="alias">The alias used to identify the specified instance.</param>
        /// <param name="instance">The instance to register.</param>
        /// <returns>Returns the current <see cref="IServiceCollection"/> instance.</returns>
        IServiceCollection AddSingleton<T>(string alias, T instance);
        IServiceCollection AddTransient<T>();
        IServiceCollection AddTransient<T>(string alias);
        IServiceCollection AddTransient<T>(IFactory<T> factory);
        IServiceCollection AddTransient<T>(string alias, IFactory<T> factory);
        IServiceCollection AddTransient<T>(Func<T> factory);
        IServiceCollection AddTransient<T>(string alias, Func<T> factory);
    }
}
