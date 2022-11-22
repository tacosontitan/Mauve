using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> AddSingleton(Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Run(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8> middleware);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8> Use(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8> middleware);
    }
}
