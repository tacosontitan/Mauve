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
        /// <param name="input1">The first input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="input2">The second input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <returns></returns>
        TOut Execute(T1 input1, T2 input2);
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="input1">The first input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="input2">The second input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <returns></returns>
        Task<TOut> ExecuteAsync(T1 input1, T2 input2);
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="input1">The first input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="input2">The second input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns></returns>
        Task<TOut> ExecuteAsync(T1 input1, T2 input2, CancellationToken cancellationToken);
    }
}
