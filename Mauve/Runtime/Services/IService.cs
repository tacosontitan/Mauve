
using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IService
    {
        IDependencyCollection Dependencies { get; set; }
        MiddlewareDelegate MiddlewareDelegate { get; set; }
    }
}
