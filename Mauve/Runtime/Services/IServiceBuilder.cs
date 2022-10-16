using System;

using Mauve.Patterns;

namespace Mauve.Runtime
{
    internal interface IServiceBuilder
    {
        IServiceBuilder AddSingleton<T>(string alias, T instance);
        IServiceBuilder AddSingleton<T>(T instance);
        IServiceBuilder AddSingleton(string alias, Type type, object instance);
        IServiceBuilder AddSingleton(Type type, object instance);
        IServiceBuilder Run(IMiddleware middleware);
        IServiceBuilder Use(IMiddleware middleware);
    }
}
