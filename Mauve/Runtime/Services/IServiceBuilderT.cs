using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T> : IServiceBuilder
    {
        IServiceBuilder Run(IMiddleware<T> middleware);
        IServiceBuilder Use(IMiddleware<T> middleware);
    }
}
