using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public class ServiceBuilder : IServiceBuilder
    {
        public IServiceBuilder AddScoped<T>() => throw new NotImplementedException();
        public IServiceBuilder AddScoped<T>(string alias) => throw new NotImplementedException();
        public IServiceBuilder AddScoped<T>(IFactory<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddScoped<T>(string alias, IFactory<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddScoped<T>(Func<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddScoped<T>(string alias, Func<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddSingleton<T>(T instance) => throw new NotImplementedException();
        public IServiceBuilder AddSingleton<T>(string alias, T instance) => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>() => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>(string alias) => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>(IFactory<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>(string alias, IFactory<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>(Func<T> factory) => throw new NotImplementedException();
        public IServiceBuilder AddTransient<T>(string alias, Func<T> factory) => throw new NotImplementedException();
        public IService Build() => throw new NotImplementedException();
        public void Run(IMiddleware middleware) => throw new NotImplementedException();
        public IServiceBuilder Use(IMiddleware middleware) => throw new NotImplementedException();
    }
}
