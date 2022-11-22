using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see cref="interface"/> capable of building an <see cref="IService{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type of the service.</typeparam>
    /// <typeparam name="T2">Specifies the second type of the service.</typeparam>
    /// <typeparam name="T3">Specifies the third type of the service.</typeparam>
    /// <typeparam name="T4">Specifies the fourth type of the service.</typeparam>
    /// <typeparam name="T5">Specifies the fifth type of the service.</typeparam>
    /// <typeparam name="T6">Specifies the sixth type of the service.</typeparam>
    /// <typeparam name="T7">Specifies the seventh type of the service.</typeparam>
    /// <typeparam name="T8">Specifies the eighth type of the service.</typeparam>
    /// <typeparam name="T9">Specifies the ninth type of the service.</typeparam>
    public interface IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IBuilder<IService<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton<T>(string alias, T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton<T>(T instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9> middleware);
        IServiceBuilder<T1, T2, T3, T4, T5, T6, T7, T8, T9> Use(IMiddleware<T1, T2, T3, T4, T5, T6, T7, T8, T9> middleware);
    }
}
