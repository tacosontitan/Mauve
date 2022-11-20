using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<T>
    {
        /// <summary>
        /// Executes the <see cref="IExecutable"/>.
        /// </summary>
        /// <returns></returns>
        T Execute();
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<T> ExecuteAsync();
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns></returns>
        Task<T> ExecuteAsync(CancellationToken cancellationToken);
    }
}
