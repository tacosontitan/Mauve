using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method.
    /// </summary>
    public interface IExecutable
    {
        /// <summary>
        /// Executes the <see cref="IExecutable"/>.
        /// </summary>
        void Execute();
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task Execute(CancellationToken cancellationToken);
    }
}
