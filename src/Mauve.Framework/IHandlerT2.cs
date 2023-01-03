using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// An <see langword="interface"/> that exposes methods to handle input and return an output.
    /// </summary>
    /// <typeparam name="TIn">Specifies the type of data used as input for the handler.</typeparam>
    /// <typeparam name="TOut">Specifies the type of data used as output for the handler.</typeparam>
    public interface IHandler<TIn, TOut>
    {
        /// <summary>
        /// Handles the input.
        /// </summary>
        /// <param name="input">The input to handle.</param>
        /// <returns>The result of handling the input.</returns>
        TOut Handle(TIn input);
        /// <summary>
        /// Handles the input.
        /// </summary>
        /// <param name="input">The input to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to allow consumers to cancel their request.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<TOut> Handle(TIn input, CancellationToken cancellationToken);
    }
}
