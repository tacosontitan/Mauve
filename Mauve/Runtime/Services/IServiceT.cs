using System;

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

        #region Methods

        /// <summary>
        /// Gets a dependency from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of dependency to get.</typeparam>
        /// <returns>Returns the identified instance of the dependency.</returns>
        TOut Get<TOut>();
        /// <summary>
        /// Gets a dependency from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of dependency to get.</typeparam>
        /// <param name="alias">The alias of the dependency.</param>
        /// <returns>Returns the identified instance of the dependency.</returns>
        TOut Get<TOut>(string alias);
        /// <summary>
        /// Gets a dependency from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the base type of the dependency to get.</typeparam>
        /// <param name="type">The specific type of dependency to get.</param>
        /// <returns>Returns the identified instance of the dependency.</returns>
        TOut Get<TOut>(Type type);

        #endregion

    }
}
