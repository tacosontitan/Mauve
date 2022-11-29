
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IService
    {
        new MiddlewareDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9> MiddlewareDelegate { get; set; }
    }
}
