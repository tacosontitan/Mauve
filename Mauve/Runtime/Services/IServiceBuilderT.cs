using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T>
    {
        IServiceBuilder<T> AddSingleton<TIn>(string alias, TIn instance);
        IServiceBuilder<T> AddSingleton<TIn>(TIn instance);
        IServiceBuilder<T> AddSingleton(string alias, Type type, object instance);
        IServiceBuilder<T> AddSingleton(Type type, object instance);
        void Run(IMiddleware<T> middleware);
        IServiceBuilder<T> Use(IMiddleware<T> middleware);
    }
}
