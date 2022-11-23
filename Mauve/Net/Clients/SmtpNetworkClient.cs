using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net.Clients
{
    internal class SmtpNetworkClient : INetworkClient
    {
        public void Send(INetworkRequest request) => throw new NotImplementedException();
        public T Send<T>(INetworkRequest request) => throw new NotImplementedException();
        public void Send<T>(INetworkRequest<T> request) => throw new NotImplementedException();
        public TOut Send<TIn, TOut>(INetworkRequest<TIn> request) => throw new NotImplementedException();
        public Task SendAsync(INetworkRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<T> SendAsync<T>(INetworkRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task SendAsync<T>(INetworkRequest<T> request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<TOut> SendAsync<TIn, TOut>(INetworkRequest<TIn> request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
