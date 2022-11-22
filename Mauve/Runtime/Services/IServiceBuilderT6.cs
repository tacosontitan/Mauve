using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4, T5, T6>
    {
        IServiceBuilder<T1, T2, T3, T4, T5, T6> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T1, T2, T3, T4, T5, T6> middleware);
        IServiceBuilder<T1, T2, T3, T4, T5, T6> Use(IMiddleware<T1, T2, T3, T4, T5, T6> middleware);
    }
}
