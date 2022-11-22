using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceDesigner
    {
        IServiceDesigner AddSingleton<T>(string alias, T instance);
        IServiceDesigner AddSingleton<T>(T instance);
        IServiceDesigner AddSingleton(string alias, Type type, object instance);
        IServiceDesigner AddSingleton(Type type, object instance);
        IServiceDesigner Run(IMiddleware middleware);
        IServiceDesigner Use(IMiddleware middleware);
    }
}
