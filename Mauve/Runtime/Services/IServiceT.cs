
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService<T>
    {
        IDependencyCollection Dependencies { get; set; }
        MiddlewareDelegate<T> MiddlewareDelegate { get; set; }
    }
}
