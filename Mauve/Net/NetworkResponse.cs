using System.Net;

namespace Mauve.Net
{
    /// <summary>
    /// Represents a <see cref="NetworkResponse{T}"/> for capturing response information during network transactions.
    /// </summary>
    /// <typeparam name="T">The type of data contained within the response.</typeparam>
    /// <inheritdoc/>
    public class NetworkResponse<T> : INetworkResponse<T>
    {
        public T Content { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSucccessful =>
            StatusCode >= System.Net.HttpStatusCode.OK ||
            StatusCode < System.Net.HttpStatusCode.MultipleChoices;
    }
}
