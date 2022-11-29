using System;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public class AbstractService<T> : IService<T>
    {
        public IDependencyCollection Dependencies { get; set; }
        public MiddlewareDelegate<T> MiddlewareDelegate { get; set; }

        public TOut Get<TOut>() => throw new System.NotImplementedException();
        public TOut Get<TOut>(string alias) => throw new System.NotImplementedException();
        public TOut Get<TOut>(Type type) => throw new NotImplementedException();
    }
}
