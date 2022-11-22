using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4>
    {
        IServiceBuilder<T1, T2, T3, T4> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2, T3, T4> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4> AddSingleton(Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4> Run(IMiddleware<T1, T2, T3, T4> middleware);
        IServiceBuilder<T1, T2, T3, T4> Use(IMiddleware<T1, T2, T3, T4> middleware);
    }
}
