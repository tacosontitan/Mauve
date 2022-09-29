using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkClientBuilder"/> instance capable of building <see cref="INetworkClient"/> instances.
    /// </summary>
    public interface INetworkClientBuilder<T> : IBuilder<T> where T : INetworkClient
    {

    }
}
