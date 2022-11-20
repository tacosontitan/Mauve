using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T, TOut>
    {
        TOut Execute(T input);
        Task<TOut> ExecuteAsync(T input);
        Task<TOut> ExecuteAsync(T input, CancellationToken cancellationToken);
    }
}
