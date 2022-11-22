using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService{T}"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the type of the service.</typeparam>
    public interface IServiceBuilder<T> : IBuilder<IService<T>>
    {
        IServiceBuilder<T> AddSingleton<TIn>(string alias, TIn instance);
        IServiceBuilder<T> AddSingleton<TIn>(TIn instance);
        IServiceBuilder<T> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T> middleware);
        IServiceBuilder<T> Use(IMiddleware<T> middleware);
    }
}
