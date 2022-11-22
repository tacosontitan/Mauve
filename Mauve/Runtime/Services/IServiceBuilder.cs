using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService"/>.
    /// </summary>
    public interface IServiceBuilder : IBuilder<IService>
    {
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddSingleton<T>(T instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        void Run(IMiddleware middleware);
        IServiceBuilder Use(IMiddleware middleware);
    }
}
