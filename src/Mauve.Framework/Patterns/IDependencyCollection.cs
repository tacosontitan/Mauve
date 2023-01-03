using System;
using System.Collections.Generic;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes methods for manipulating a collection of dependencies.
    /// </summary>
    /// <remarks>Derives from <see cref="IList{T}"/>.</remarks>
    public interface IDependencyCollection : IList<DependencyDescriptor>
    {
        IDependencyCollection AddScoped<T>();
        IDependencyCollection AddScoped<T>(string alias);
        IDependencyCollection AddScoped<T>(IFactory<T> factory);
        IDependencyCollection AddScoped<T>(string alias, IFactory<T> factory);
        IDependencyCollection AddScoped<T>(Func<T> factory);
        IDependencyCollection AddScoped<T>(string alias, Func<T> factory);
        /// <summary>
        /// Adds an instance of the specified type to the collection.
        /// </summary>
        /// <typeparam name="T">The type of the instance to add.</typeparam>
        /// <param name="singleton">The instance to add to the collection.</param>
        /// <returns>Returns the current <see cref="IDependencyCollection"/>.</returns>
        IDependencyCollection AddSingleton<T>(T singleton);
        /// <summary>
        /// Adds an instance of the specified type to the collection.
        /// </summary>
        /// <param name="type">The type of the instance to add.</param>
        /// <param name="instance">The instance to add to the collection.</param>
        /// <returns>Returns the current <see cref="IDependencyCollection"/>.</returns>
        IDependencyCollection AddSingleton(Type type, object instance);
        IDependencyCollection AddTransient<T>();
        IDependencyCollection AddTransient<T>(string alias);
        IDependencyCollection AddTransient<T>(IFactory<T> factory);
        IDependencyCollection AddTransient<T>(string alias, IFactory<T> factory);
        IDependencyCollection AddTransient<T>(Func<T> factory);
        IDependencyCollection AddTransient<T>(string alias, Func<T> factory);
    }
}
