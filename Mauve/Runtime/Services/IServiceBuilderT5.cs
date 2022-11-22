using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    public interface IServiceBuilder<T1, T2, T3, T4, T5> : IServiceBuilder
    {
        IServiceBuilder Run(IMiddleware<T1, T2, T3, T4, T5> middleware);
        IServiceBuilder Use(IMiddleware<T1, T2, T3, T4, T5> middleware);
    }
}
