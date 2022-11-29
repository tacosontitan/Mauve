using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes methods for executing and rolling back commands.
    /// </summary>
    /// <remarks>Derives from <see cref="IExecutable"/>.</remarks>
    internal interface ICommand : IExecutable
    {
        /// <summary>
        /// Performs a rollback operation for the command.
        /// </summary>
        void Rollback();
        /// <summary>
        /// Performs a rollback operation for the command.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to cancel asynchronous processing.</param>
        Task Rollback(CancellationToken cancellationToken);
    }
}
