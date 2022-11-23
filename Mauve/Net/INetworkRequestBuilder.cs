using System;

using Mauve.Patterns;

namespace Mauve.Net
{
    public interface INetworkRequestBuilder : IBuilder<INetworkRequest>
    {
        INetworkRequestBuilder Authorize(string username, string password);
        INetworkRequestBuilder Authorize(NetworkTokenType tokenType, string token);
        INetworkRequestBuilder Delete(string uri);
        INetworkRequestBuilder Delete(Uri uri);
        INetworkRequestBuilder Get(string uri);
        INetworkRequestBuilder Get(Uri uri);
        INetworkRequestBuilder Patch(string uri);
        INetworkRequestBuilder Patch(Uri uri);
        INetworkRequestBuilder Post(string uri);
        INetworkRequestBuilder Post(Uri uri);
        INetworkRequestBuilder Put(string uri);
        INetworkRequestBuilder Put(Uri uri);
        INetworkRequestBuilder UsingPort(int port);
        INetworkRequestBuilder WithHeader<T>(string key, T value);
        INetworkRequestBuilder WithParameter<T>(string key, T value);
        INetworkRequestBuilder Write<T>(T data);
    }
}
