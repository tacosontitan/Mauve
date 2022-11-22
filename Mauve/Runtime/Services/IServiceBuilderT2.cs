using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2> : IServiceBuilder
    {
        IServiceBuilder Run(IMiddleware<T1, T2> middleware);
        IServiceBuilder Use(IMiddleware<T1, T2> middleware);
    }
}
