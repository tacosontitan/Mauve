﻿
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type of data utilized in requests to this service.</typeparam>
    /// <typeparam name="T2">Specifies the second type of data utilized in requests to this service.</typeparam>
    public interface IService<T1, T2>
    {
        /// <summary>
        /// A collection of dependencies for the service.
        /// </summary>
        IDependencyCollection Dependencies { get; set; }
        /// <summary>
        /// The middleware delegate the service runs requests through.
        /// </summary>
        MiddlewareDelegate<T1, T2> MiddlewareDelegate { get; set; }
    }
}
