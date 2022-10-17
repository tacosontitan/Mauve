using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddSingleton<T>(T instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        IServiceBuilder Run(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8> middleware);
        IServiceBuilder Use(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8> middleware);
    }
}
