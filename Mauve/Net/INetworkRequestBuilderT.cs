using Mauve.Patterns;

namespace Mauve.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INetworkRequestBuilder<T> : IBuilder<INetworkRequest<T>>
    {
        INetworkRequestBuilder<T> Authorize(NetworkTokenType tokenType, string token);
        INetworkRequestBuilder<T> Authorize(string username, string password);
        INetworkRequestBuilder<T> Delete(string uri);
        INetworkRequestBuilder<T> Get(string uri);
        INetworkRequestBuilder<T> Patch(string uri);
        INetworkRequestBuilder<T> Post(string uri);
        INetworkRequestBuilder<T> Put(string uri);
        INetworkRequestBuilder<T> UsingPort(int port);
        INetworkRequestBuilder<T> WithHeader<THeader>(string key, THeader value);
        INetworkRequestBuilder<T> WithParameter<TParameter>(string name, TParameter value);
        INetworkRequestBuilder<T> Write(T data);
    }
}
