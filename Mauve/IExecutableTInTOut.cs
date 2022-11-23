using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    public interface IExecutable<TIn, TOut>
    {
        /// <summary>
        /// Executes the <see cref="IExecutable{TIn, TOut}"/>.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{TIn, TOut}"/>.</param>
        TOut Execute(TIn input);
        /// <summary>
        /// Executes the <see cref="IExecutable{TIn, TOut}"/>.
        /// </summary>
        /// <param name="input">The input parameter for this <see cref="IExecutable{TIn, TOut}"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        Task<TOut> Execute(TIn input, CancellationToken cancellationToken);
    }
}
