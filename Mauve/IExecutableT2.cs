using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T1, T2, TOut>
    {
        /// <summary>
        ///  Executes the <see cref="IExecutable"/>.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        TOut Execute(T1 input1, T2 input2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        Task<TOut> ExecuteAsync(T1 input1, T2 input2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns></returns>
        Task<TOut> ExecuteAsync(T1 input1, T2 input2, CancellationToken cancellationToken);
    }
}
