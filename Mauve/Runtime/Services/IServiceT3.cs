
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService<T1, T2, T3>
    {
        IDependencyCollection Dependencies { get; set; }
        MiddlewareDelegate<T1, T2, T3> MiddlewareDelegate { get; set; }
    }
}
