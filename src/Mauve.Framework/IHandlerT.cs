using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// An <see langword="interface"/> that exposes methods to handle input.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data used as input for the handler.</typeparam>
    public interface IHandler<T>
    {
        /// <summary>
        /// Handles the input.
        /// </summary>
        /// <param name="input">The input to handle.</param>
        void Handle(T input);
        /// <summary>
        /// Handles the input.
        /// </summary>
        /// <param name="input">The input to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to allow consumers to cancel their request.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task Handle(T input, CancellationToken cancellationToken);
    }
}
