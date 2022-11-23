
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService<T1, T2, T3> : IService
    {
        new MiddlewareDelegate<T1, T2, T3> MiddlewareDelegate { get; set; }
    }
}
