using System;

using Mauve.Patterns;

namespace Mauve.Net
{
    public interface INetworkRequestBuilder<TRequest, TData> : IBuilder<TRequest>
        where TRequest : INetworkRequest<TData>
    {
        /// <summary>
        /// Authorizes the request using the specified <see cref="NetworkCredential"/>.
        /// </summary>
        /// <param name="networkCredential">The network credential to authorize with.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Authorize(NetworkCredential networkCredential);
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Delete"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Delete();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Get"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Get();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Patch"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Patch();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Post"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Post();
        /// <summary>
        /// Sets the method of the request to <see cref="NetworkRequestMethod.Put"/>.
        /// </summary>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Put();
        /// <summary>
        /// Specifies where the request is going.
        /// </summary>
        /// <param name="uri">The host of the connection (e.g. the IP Address, Server Name, Base URL, etc).</param>
        /// <param name="port">The port this connection uses.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> To(Uri uri, int? port = null);
        /// <summary>
        /// Adds the specified header to the <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data the value for the header is.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> UseHeader<T>(string key, T value);
        /// <summary>
        /// Writes the specified <see cref="TData"/> to the request.
        /// </summary>
        /// <param name="data">The data to send with the request.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> Write(TData data);
    }
}
