using System.Threading.Tasks;

namespace Mauve.Patterns
{
    public delegate Task MiddlewareDelegate();
    public delegate Task MiddlewareDelegate<T>(T input);
    public delegate Task MiddlewareDelegate<T, U>(T t, U u);
    public delegate Task MiddlewareDelegate<T, U, V>(T t, U u, V v);
}
