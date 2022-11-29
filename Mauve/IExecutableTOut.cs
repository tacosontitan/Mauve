using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    /// <typeparam name="T">Specifies the expected result type for the operation.</typeparam>
    public interface IExecutable<T>
    {
        /// <summary>
        /// Executes the <see cref="IExecutable"/>.
        /// </summary>
        /// <returns>The result of the operation.</returns>
        T Execute();
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<T> Execute(CancellationToken cancellationToken);
    }
}
