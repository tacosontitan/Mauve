using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// An <see langword="interface"/> for building <see cref="INetworkRequest{T}"/> instances.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data utilized by the request.</typeparam>
    public interface INetworkRequestBuilder<T> : IBuilder<INetworkRequest<T>>
    {
        /// <summary>
        /// Adds basic authorization to the request.
        /// </summary>
        /// <param name="username">The authorized user's username.</param>
        /// <param name="password">The authorized user's password.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Authorize(NetworkTokenType tokenType, string token);
        /// <summary>
        /// Adds a token based authorization header to the request.
        /// </summary>
        /// <param name="tokenType">The type of token being utilized.</param>
        /// <param name="token">The token to utilize.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Authorize(string username, string password);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Delete"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Delete(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Get"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Get(string uri);
        /// <summary>
        /// Specifies that HttpMethod.Patch should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Patch(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Post"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Post(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Put"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Put(string uri);
        /// <summary>
        /// Specifies which port the request should be sent through.
        /// </summary>
        /// <param name="port">The port the request should be sent through.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> UsingPort(int port);
        /// <summary>
        /// Adds a header to the request.
        /// </summary>
        /// <typeparam name="THeader">Specifies the type of data for the header.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> WithHeader<THeader>(string key, THeader value);
        /// <summary>
        /// Adds a parameter to the request.
        /// </summary>
        /// <typeparam name="TParameter">Specifies the type of data for the parameter.</typeparam>
        /// <param name="key">The key for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> WithParameter<TParameter>(string name, TParameter value);
        /// <summary>
        /// Writes the specified data to the body of the request.
        /// </summary>
        /// <param name="data">The data to write to the request.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder{T}"/> instance.</returns>
        INetworkRequestBuilder<T> Write(T data);
    }
}
