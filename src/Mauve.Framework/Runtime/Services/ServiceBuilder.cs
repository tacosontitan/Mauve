//using System;

//using Mauve.Patterns;

//namespace Mauve.Runtime.Services
//{
//    public class ServiceBuilder : IServiceCollection
//    {
//        public IServiceCollection AddScoped<T>() => throw new NotImplementedException();
//        public IServiceCollection AddScoped<T>(string alias) => throw new NotImplementedException();
//        public IServiceCollection AddScoped<T>(IFactory<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddScoped<T>(string alias, IFactory<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddScoped<T>(Func<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddScoped<T>(string alias, Func<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddSingleton<T>(T instance) => throw new NotImplementedException();
//        public IServiceCollection AddSingleton<T>(string alias, T instance) => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>() => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>(string alias) => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>(IFactory<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>(string alias, IFactory<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>(Func<T> factory) => throw new NotImplementedException();
//        public IServiceCollection AddTransient<T>(string alias, Func<T> factory) => throw new NotImplementedException();
//        public IService Build() => throw new NotImplementedException();
//        public void Run(IMiddleware middleware) => throw new NotImplementedException();
//        public IServiceCollection Use(IMiddleware middleware) => throw new NotImplementedException();
//    }
//}
