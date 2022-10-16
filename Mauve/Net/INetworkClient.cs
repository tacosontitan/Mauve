using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see langword="interface"/> which exposes methods for executing an <see cref="INetworkRequest{T}"/>.
    /// </summary>
    public interface INetworkClient
    {

        #region Properties

        /// <summary>
        /// The base <see cref="Uri"/> this <see cref="INetworkClient"/> operates within.
        /// </summary>
        Uri BaseUri { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
        /// <typeparam name="TIn">Specifies the type of data the request works with.</typeparam>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        INetworkResponse<TOut> Execute<TRequest, TIn, TOut>(TRequest request) where TRequest : INetworkRequest<TIn>;
        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
        /// <typeparam name="TIn">Specifies the type of data the request works with.</typeparam>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        Task<INetworkResponse<TOut>> ExecuteAsync<TRequest, TIn, TOut>(TRequest request) where TRequest : INetworkRequest<TIn>;
        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
        /// <typeparam name="TIn">Specifies the type of data the request works with.</typeparam>
        /// <typeparam name="TOut">Specifies the type of data expected in the response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns an <see cref="INetworkResponse{T}"/>.</returns>
        Task<INetworkResponse<TOut>> ExecuteAsync<TRequest, TIn, TOut>(TRequest request, CancellationToken cancellationToken) where TRequest : INetworkRequest<TIn>;

        #endregion

    }
}
