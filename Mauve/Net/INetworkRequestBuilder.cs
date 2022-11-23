using Mauve.Patterns;

namespace Mauve.Net
{
    public interface INetworkRequestBuilder : IBuilder<INetworkRequest>
    {
        INetworkRequestBuilder Authorize(string username, string password);
        INetworkRequestBuilder Authorize(NetworkTokenType tokenType, string token);
        INetworkRequestBuilder Delete(string uri);
        INetworkRequestBuilder Get(string uri);
        INetworkRequestBuilder Patch(string uri);
        INetworkRequestBuilder Post(string uri);
        INetworkRequestBuilder Put(string uri);
        INetworkRequestBuilder UsingPort(int port);
        INetworkRequestBuilder WithHeader<T>(string key, T value);
        INetworkRequestBuilder WithParameter<T>(string key, T value);
    }
}
