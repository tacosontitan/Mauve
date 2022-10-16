using System;

using Mauve.Patterns;

namespace Mauve.Runtime
{
    public interface IServiceBuilder<T>
    {
        IServiceBuilder AddSingleton<TIn>(string alias, TIn instance);
        IServiceBuilder AddSingleton<TIn>(TIn instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        IServiceBuilder Run(IMiddleware<T> middleware);
        IServiceBuilder Use(IMiddleware<T> middleware);
    }
}
