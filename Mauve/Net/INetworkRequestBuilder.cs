using System;

using Mauve.Patterns;

namespace Mauve.Net
{
    public interface INetworkRequestBuilder<T> : IBuilder<INetworkRequest<T>>
    {
        /// <summary>
        /// Authorizes the request using the specified <see cref="NetworkCredential"/>.
        /// </summary>
        /// <param name="networkCredential">The network credential to authorize with.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Authorize(NetworkCredential networkCredential);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Delete"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Delete();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Get"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Get();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Patch"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Patch();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Post"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Post();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Put"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Put();
        /// <summary>
        /// Specifies where the request is going.
        /// </summary>
        /// <param name="uri">The host of the connection (e.g. the IP Address, Server Name, Base URL, etc).</param>
        /// <param name="port">The port this connection uses.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Using(Uri uri, int? port = null);
        /// <summary>
        /// Adds the specified header to the <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data the value for the header is.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> UseHeader<THeader>(string key, THeader value);
        /// <summary>
        /// Writes the specified <see cref="TData"/> to the request.
        /// </summary>
        /// <param name="data">The data to send with the request.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<T> Write(T data);
    }
}
