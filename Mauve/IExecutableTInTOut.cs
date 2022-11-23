using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    /// <typeparam name="TIn">Specifies the first type of input for the operation.</typeparam>
    /// <typeparam name="TOut">Specifies the expected result type for the operation.</typeparam>
    public interface IExecutable<TIn, TOut>
    {
        /// <summary>
        /// Executes the <see cref="IExecutable{TIn, TOut}"/>.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{TIn, TOut}"/>.</param>
        /// <returns>The result of the operation.</returns>
        TOut Execute(TIn input);
        /// <summary>
        /// Executes the <see cref="IExecutable{TIn, TOut}"/>.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{TIn, TOut}"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<TOut> Execute(TIn input, CancellationToken cancellationToken);
    }
}
