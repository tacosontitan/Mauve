using System;

using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INetworkRequestBuilder<T> : IBuilder<INetworkRequest<T>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenType"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        INetworkRequestBuilder<T> Authorize(NetworkTokenType tokenType, string token);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        INetworkRequestBuilder<T> Authorize(string username, string password);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Delete"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Delete(Uri uri, bool append = false);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Get"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Get(Uri uri, bool append = false);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Patch"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Patch(Uri uri, bool append = false);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Post"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Post(Uri uri, bool append = false);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Put"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Put(Uri uri, bool append = false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        INetworkRequestBuilder<T> UsingPort(int port);
        /// <summary>
        /// Adds the specified header to the <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data the value for the header is.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> WithHeader<THeader>(string key, THeader value);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        INetworkRequestBuilder<T> WithParameter<TParameter>(string name, TParameter value);
        /// <summary>
        /// Writes the specified <see cref="TData"/> to the request.
        /// </summary>
        /// <param name="data">The data to send with the request.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Write(T data);
    }
}
