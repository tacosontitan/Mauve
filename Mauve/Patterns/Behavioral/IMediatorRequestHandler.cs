using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns.Behavioral
{
    /// <summary>
    /// An <see cref="interface"/> which exposes methods for handling requests from an <see cref="IMediator"/> instance.
    /// </summary>
    /// <typeparam name="TIn">Specifies the type of data coming in.</typeparam>
    /// <typeparam name="TOut">Specifies the data coming back.</typeparam>
    public interface IMediatorRequestHandler<TIn, TOut>
    {
        /// <summary>
        /// Handles a request from an <see cref="IMediator"/> instance.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <returns>The response of the handled request.</returns>
        TOut Handle(TIn request);
        /// <summary>
        /// Handles a request from an <see cref="IMediator"/> instance.
        /// </summary>
        /// <param name="input">The input for the request.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TOut}"/> representing the state of the execution.</returns>
        Task<TOut> Handle(TIn request, CancellationToken cancellationToken);
    }
}
