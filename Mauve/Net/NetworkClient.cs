using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Extensibility;

namespace Mauve.Net
{
    /// <summary>
    /// Represents a <see langword="abstract"/> implementation of <see cref="INetworkClient"/> that handles exceptions and response codes natively.
    /// </summary>
    /// <inheritdoc/>
    public abstract class NetworkClient : INetworkClient
    {

        #region Properties

        public Uri BaseUri { get; set; }

        #endregion

        public NetworkClient(string baseUri) :
            this(new Uri(baseUri))
        { }
        public NetworkClient(Uri baseUri) =>
            BaseUri = baseUri;

        #region Public Methods

        public virtual INetworkResponse<TOut> Execute<TRequest, TIn, TOut>(TRequest request)
            where TRequest : INetworkRequest<TIn>
        {
            TOut response = default;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string responseMessage = string.Empty;
            try
            {
                response = ExecuteRequest<TRequest, TIn, TOut>(request);
                statusCode = HttpStatusCode.OK;
                responseMessage = "Success.";
            } catch (Exception e)
            {
                IEnumerable<Exception> flattenedExceptionTree = e.Flatten();
                IEnumerable<string> exeptionMessages = flattenedExceptionTree.Select(exception => exception.Message);
                responseMessage = string.Join(" ", exeptionMessages);
            }

            // Return the network response.
            return new NetworkResponse<TOut>
            {
                Content = response,
                StatusCode = statusCode,
                Message = responseMessage
            };
        }
        public async Task<INetworkResponse<TOut>> ExecuteAsync<TRequest, TIn, TOut>(TRequest request)
            where TRequest : INetworkRequest<TIn> =>
                await ExecuteAsync<TRequest, TIn, TOut>(request, CancellationToken.None);
        public async Task<INetworkResponse<TOut>> ExecuteAsync<TRequest, TIn, TOut>(TRequest request, CancellationToken cancellationToken)
            where TRequest : INetworkRequest<TIn> =>
                await Task.Run(() => Execute<TRequest, TIn, TOut>(request), cancellationToken);

        #endregion

        #region Protected Methods

        /// <summary>
        /// Executes the specified <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <param name="request">The request to execute.</param>
        /// <returns>Returns the appropriate <see cref="TOut"/> instance representing the result of executing the specified <see cref="TRequest"/>.</returns>
        protected abstract TOut ExecuteRequest<TRequest, TIn, TOut>(TRequest request) where TRequest : INetworkRequest<TIn>;

        #endregion

    }
}
