using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see langword="interface"/> which exposes methods for executing an <see cref="INetworkRequest{T}"/>.
    /// </summary>
    public interface INetworkClient<TRequest, TIn>
        where TRequest : INetworkRequest<TIn>
    {

        #region Methods

        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        INetworkResponse<TOut> Execute<TOut>(TRequest request);
        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        Task<INetworkResponse<TOut>> ExecuteAsync<TOut>(TRequest request);
        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        Task<INetworkResponse<TOut>> ExecuteAsync<TOut>(TRequest request, CancellationToken cancellationToken);

        #endregion

    }
}
