using System;

using Mauve.Patterns;

namespace Mauve.Runtime
{
    public interface IServiceBuilder<T1, T2>
    {
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddSingleton<T>(T instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        IServiceBuilder Run(IMiddleware<T1, T2> middleware);
        IServiceBuilder Use(IMiddleware<T1, T2> middleware);
    }
}
