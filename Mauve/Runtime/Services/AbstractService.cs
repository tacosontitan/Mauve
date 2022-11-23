using System;

namespace Mauve.Runtime.Services
{
    public abstract class AbstractService : IService
    {
        public abstract void Configure(IServiceCollection service);
        public TOut Get<TOut>() => throw new NotImplementedException();
        public TOut Get<TOut>(string alias) => throw new NotImplementedException();
        public TOut Get<TOut>(Type type) => throw new NotImplementedException();
        public T Get<T>(Predicate<T> predicate) => throw new NotImplementedException();
    }
}
