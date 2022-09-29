using System.Net;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkResponse{T}"/> instance utilized to capture a network response.
    /// </summary>
    public interface INetworkResponse<T>
    {
        /// <summary>
        /// The content of the response.
        /// </summary>
        T Content { get; set; }
        /// <summary>
        /// The message associated with the response.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// The status of the response using codes defined for HTTP.
        /// </summary>
        HttpStatusCode StatusCode { get; set; }
    }
}
