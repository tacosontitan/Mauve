using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2>
    {
        IServiceBuilder<T1, T2> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2> AddSingleton(Type type, object instance);
        IServiceBuilder<T1, T2> Run(IMiddleware<T1, T2> middleware);
        IServiceBuilder<T1, T2> Use(IMiddleware<T1, T2> middleware);
    }
}
