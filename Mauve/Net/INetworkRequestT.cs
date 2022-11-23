namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkRequest{T}"/> instance utilized for requesting data over a network.
    /// </summary>
    public interface INetworkRequest<T> : INetworkRequest
    {
        /// <summary>
        /// The data for this specific request.
        /// </summary>
        T Data { get; set; }
    }
}
