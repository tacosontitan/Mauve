using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes an execute method which returns data.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type of input for the operation.</typeparam>
    /// <typeparam name="T2">Specifies the second type of input for the operation.</typeparam>
    /// <typeparam name="TOut">Specifies the expected result type for the operation.</typeparam>
    public interface IExecutable<T1, T2, TOut>
    {
        /// <summary>
        ///  Executes the <see cref="IExecutable"/>.
        /// </summary>
        /// <param name="input1">The first input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="input2">The second input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <returns>The result of the operation.</returns>
        TOut Execute(T1 input1, T2 input2);
        /// <summary>
        /// Executes the <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <param name="input1">The first input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="input2">The second input parameter for this <see cref="IExecutable{T, TOut}"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel execution.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<TOut> Execute(T1 input1, T2 input2, CancellationToken cancellationToken);
    }
}
