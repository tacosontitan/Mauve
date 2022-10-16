using System.Collections.Generic;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkRequest{T}"/> instance utilized for requesting data over a network.
    /// </summary>
    public interface INetworkRequest<T>
    {
        /// <summary>
        /// The method utilized by this request.
        /// </summary>
        NetworkRequestMethod Method { get; set; }
        /// <summary>
        /// The data for this specific request.
        /// </summary>
        T Data { get; set; }
        /// <summary>
        /// The headers utilized in the request.
        /// </summary>
        Dictionary<string, object> Headers { get; set; }
    }
}
