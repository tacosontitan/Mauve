using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4> : IServiceBuilder
    {
        IServiceBuilder Run(IMiddleware<T1, T2, T3, T4> middleware);
        IServiceBuilder Use(IMiddleware<T1, T2, T3, T4> middleware);
    }
}
