using System.Net.Http;

using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// An <see langword="interface"/> for building <see cref="INetworkRequest"/> instances.
    /// </summary>
    public interface INetworkRequestBuilder : IBuilder<INetworkRequest>
    {
        /// <summary>
        /// Adds basic authorization to the request.
        /// </summary>
        /// <param name="username">The authorized user's username.</param>
        /// <param name="password">The authorized user's password.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Authorize(string username, string password);
        /// <summary>
        /// Adds a token based authorization header to the request.
        /// </summary>
        /// <param name="tokenType">The type of token being utilized.</param>
        /// <param name="token">The token to utilize.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Authorize(NetworkTokenType tokenType, string token);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Delete"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Delete(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Get"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Get(string uri);
        /// <summary>
        /// Specifies that HttpMethod.Patch should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Patch(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Post"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Post(string uri);
        /// <summary>
        /// Specifies that <see cref="HttpMethod.Put"/> should be used for the request to the specified resource.
        /// </summary>
        /// <param name="uri">The universal resource identifier the request is for.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder Put(string uri);
        /// <summary>
        /// Specifies which port the request should be sent through.
        /// </summary>
        /// <param name="port">The port the request should be sent through.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder UsingPort(int port);
        /// <summary>
        /// Adds a header to the request.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data for the header.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder WithHeader<T>(string key, T value);
        /// <summary>
        /// Adds a parameter to the request.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data for the parameter.</typeparam>
        /// <param name="key">The key for the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The current <see cref="INetworkRequestBuilder"/> instance.</returns>
        INetworkRequestBuilder WithParameter<T>(string key, T value);
    }
}
