using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    public class MsSqlNetworkClient : INetworkClient
    {

        #region Fields

        private readonly string _server;
        private readonly string _database;
        private readonly string _username;
        private readonly string _password;
        private readonly TimeSpan _timeout;

        #endregion

        public MsSqlNetworkClient() { }
        public MsSqlNetworkClient(string server, string database)
        {
            _server = server;
            _database = database;
        }
        public MsSqlNetworkClient(string server, string database, TimeSpan timeout) :
            this(server, database) =>
            _timeout = timeout;
        public MsSqlNetworkClient(string server, string database, string username, string password) :
            this(server, database)
        {
            _username = username;
            _password = password;
        }
        public MsSqlNetworkClient(string server, string database, string username, string password, TimeSpan timeout) :
            this(server, database, username, password) =>
            _timeout = timeout;

        #region Public Methods

        public void Send(INetworkRequest request) => throw new NotImplementedException();
        public T Send<T>(INetworkRequest request) => throw new NotImplementedException();
        public void Send<T>(INetworkRequest<T> request) => throw new NotImplementedException();
        public TOut Send<TIn, TOut>(INetworkRequest<TIn> request) => throw new NotImplementedException();
        public Task SendAsync(INetworkRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<T> SendAsync<T>(INetworkRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task SendAsync<T>(INetworkRequest<T> request, CancellationToken cancellationToken) => throw new NotImplementedException();
        public Task<TOut> SendAsync<TIn, TOut>(INetworkRequest<TIn> request, CancellationToken cancellationToken) => throw new NotImplementedException();

        #endregion

    }
}
