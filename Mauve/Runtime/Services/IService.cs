
using Mauve.Patterns;

namespace Mauve.Runtime
{
    public interface IService
    {
        IDependencyCollection Dependencies { get; set; }
        MiddlewareDelegate MiddlewareDelegate { get; set; }
    }
}
