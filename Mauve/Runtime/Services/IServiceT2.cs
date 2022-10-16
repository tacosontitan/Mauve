
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService<T1, T2>
    {
        IDependencyCollection Dependencies { get; set; }
        MiddlewareDelegate<T1, T2> MiddlewareDelegate { get; set; }
    }
}
