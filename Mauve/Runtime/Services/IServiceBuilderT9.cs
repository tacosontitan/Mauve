using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9> middleware);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Use(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9> middleware);
    }
}
