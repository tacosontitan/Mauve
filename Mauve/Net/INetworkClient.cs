using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    /// <summary>
    /// An <see langword="interface"/> that exposes methods for sending <see cref="INetworkRequest"/> instances.
    /// </summary>
    public interface INetworkClient
    {
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest"/> to the client.
        /// </summary>
        /// <param name="request">The request to send.</param>
        void Send(INetworkRequest request);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest"/> to the client.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request to send.</param>
        /// <returns>The response data from the client.</returns>
        T Send<T>(INetworkRequest request);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest{TIn}"/> to the client.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data contained in the <see cref="INetworkRequest{T}"/>.</typeparam>
        /// <param name="request">The request to send.</param>
        void Send<T>(INetworkRequest<T> request);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest{TIn}"/> to the client.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of data contained in the <see cref="INetworkRequest{T}"/>.</typeparam>
        /// <typeparam name="TOut">Specifies the type of data expected to be returned from the client.</typeparam>
        /// <param name="request">The request to send.</param>
        /// <returns>The response data from the client.</returns>
        TOut Send<TIn, TOut>(INetworkRequest<TIn> request);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest"/> to the client asynchronously.
        /// </summary>
        /// <param name="request">The request to send.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task SendAsync(INetworkRequest request, CancellationToken cancellationToken);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest"/> to the client asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request to send.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<T> SendAsync<T>(INetworkRequest request, CancellationToken cancellationToken);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest{T}"/> to the client asynchronously.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data contained in the <see cref="INetworkRequest{T}"/>.</typeparam>
        /// <param name="request">The request to send.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task SendAsync<T>(INetworkRequest<T> request, CancellationToken cancellationToken);
        /// <summary>
        /// Sends the specified <see cref="INetworkRequest{T}"/> to the client asynchronously.
        /// </summary>
        /// <typeparam name="TIn">Specifies the type of data contained in the <see cref="INetworkRequest{T}"/>.</typeparam>
        /// <typeparam name="TOut">Specifies the type of data expected to be returned from the client.</typeparam>
        /// <param name="request">The request to send.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>A <see cref="Task"/> describing the state of the operation.</returns>
        Task<TOut> SendAsync<TIn, TOut>(INetworkRequest<TIn> request, CancellationToken cancellationToken);
    }
}
