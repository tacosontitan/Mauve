using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T1, T2, T3, T4, T5, TOut>
    {
        TOut Execute(T1 input1, T2 input2, T3 input3, T4 input4, T5 input5);
        Task<TOut> ExecuteAsync(T1 input1, T2 input2, T3 input3, T4 input4, T5 input5);
        Task<TOut> ExecuteAsync(T1 input1, T2 input2, T3 input3, T4 input4, T5 input5, CancellationToken cancellationToken);
    }
}
