using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public abstract class AbstractService : IService
    {
        public abstract void Configure(IDependencyCollection dependencies, IServicePipeline pipeline);
        public TOut Get<TOut>() => throw new NotImplementedException();
        public TOut Get<TOut>(string alias) => throw new NotImplementedException();
        public TOut Get<TOut>(Type type) => throw new NotImplementedException();
        public T Get<T>(Predicate<T> predicate) => throw new NotImplementedException();
    }
}
