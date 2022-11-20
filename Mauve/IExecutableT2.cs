using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<TIn, TOut>
    {
        TOut Execute(TIn input);
        Task<TOut> ExecuteAsync(TIn input);
        Task<TOut> ExecuteAsync(TIn input, CancellationToken cancellationToken);
    }
}
