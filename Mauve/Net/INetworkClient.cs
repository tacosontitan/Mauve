namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkClient"/> instance capable of executing <see cref="INetworkRequest"/> instances.
    /// </summary>
    public interface INetworkClient<T> where T : INetworkRequest
    {
        INetworkResponse Execute(T request);
    }
}
