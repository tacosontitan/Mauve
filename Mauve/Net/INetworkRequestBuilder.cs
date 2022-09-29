using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkRequestBuilder"/> instance capable of building <see cref="INetworkRequest"/> instances.
    /// </summary>
    public interface INetworkRequestBuilder<T> : IBuilder<T> where T : INetworkRequest
    {
    }
}
