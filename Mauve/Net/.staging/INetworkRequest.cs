using System;
using System.Collections.Generic;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkRequest{T}"/> instance utilized for requesting data over a network.
    /// </summary>
    public interface INetworkRequest<T>
    {
        /// <summary>
        /// The credential to be utilized for connection.
        /// </summary>
        NetworkCredential Credentials { get; set; }
        /// <summary>
        /// The data for this specific request.
        /// </summary>
        T Data { get; set; }
        /// <summary>
        /// The headers utilized in the request.
        /// </summary>
        Dictionary<string, object> Headers { get; set; }
        /// <summary>
        /// The method utilized by this request.
        /// </summary>
        NetworkRequestMethod Method { get; set; }
        /// <summary>
        /// The port this connection uses.
        /// </summary>
        int? Port { get; set; }
        /// <summary>
        /// The host of the connection (e.g. the IP Address, Server Name, Base URL, etc).
        /// </summary>
        Uri Uri { get; set; }
    }
}
