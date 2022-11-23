using System.Collections.Generic;
using System.Net.Http;

namespace Mauve.Net
{
    /// <summary>
    /// An <see langword="interface"/> that exposes properties of a basic network request.
    /// </summary>
    public interface INetworkRequest
    {
        /// <summary>
        /// The port to use for the request.
        /// </summary>
        int? Port { get; set; }
        /// <summary>
        /// The universal resource identifier the request is for.
        /// </summary>
        string Uri { get; set; }
        /// <summary>
        /// The <see cref="HttpMethod"/> of the request.
        /// </summary>
        HttpMethod Method { get; set; }
        /// <summary>
        /// The headers for the request.
        /// </summary>
        Dictionary<string, object> Headers { get; set; }
        /// <summary>
        /// The parameters for the request.
        /// </summary>
        Dictionary<string, object> Parameters { get; set; }
    }
}
