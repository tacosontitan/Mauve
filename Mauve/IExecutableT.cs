using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T, TOut>
    {
        /// <summary>
        /// Executes the <see cref="IExecutable"/>.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        TOut Execute(T input);
        /// <summary>
        /// Executes the <see cref="IExecutable{T, TOut}"/> asynchronously.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        Task<TOut> ExecuteAsync(T input);
        /// <summary>
        /// Executes the <see cref="IExecutable{T, TOut}"/> asynchronously.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        Task<TOut> ExecuteAsync(T input, CancellationToken cancellationToken);
    }
}
