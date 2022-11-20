using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<TOut, T1, T2>
    {
        TOut Execute(T1 input1, T2 input2);
        Task<TOut> ExecuteAsync(T1 input1, T2 input2);
        Task<TOut> ExecuteAsync(T1 input1, T2 input2, CancellationToken cancellationToken);
    }
}
