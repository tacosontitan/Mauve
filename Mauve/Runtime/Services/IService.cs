
using System;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    public interface IService
    {

        #region Methods

        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="service">The <see cref="IServiceBuilder"/> used to configure the service.</param>
        void Configure(IServiceBuilder service);
        /// <summary>
        /// Gets a resource from the service.
        /// </summary>
        /// <typeparam name="T">Specifies the type of resource to get.</typeparam>
        /// <param name="predicate">The predicate used to identify the resource.</param>
        /// <returns>The identified instance of the resource.</returns>
        T Get<T>(Predicate<T> predicate);
        /// <summary>
        /// Gets a resource from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of resource to get.</typeparam>
        /// <returns>Returns the identified instance of the resource.</returns>
        TOut Get<TOut>();
        /// <summary>
        /// Gets a resource from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of resource to get.</typeparam>
        /// <param name="alias">The alias of the resource.</param>
        /// <returns>Returns the identified instance of the resource.</returns>
        TOut Get<TOut>(string alias);
        /// <summary>
        /// Gets a resource from the service.
        /// </summary>
        /// <typeparam name="TOut">Specifies the base type of the resource to get.</typeparam>
        /// <param name="type">The specific type of resource to get.</param>
        /// <returns>Returns the identified instance of the resource.</returns>
        TOut Get<TOut>(Type type);

        #endregion

    }
}
