using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TIn"></typeparam>
    public abstract class VerboseNetworkClient<TRequest, TIn> : NetworkClient<TRequest, TIn>
        where TRequest : INetworkRequest<TIn>
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri"></param>
        public VerboseNetworkClient(NetworkConnectionInformation connectionInformation) :
            base(connectionInformation)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public INetworkResponse<TOut> Get<TOut>(TRequest request) =>
            Execute<TOut>(request, NetworkRequestMethod.Get);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> GetAsync<TOut>(TRequest request) =>
            await GetAsync<TOut>(request, CancellationToken.None);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> GetAsync<TOut>(TRequest request, CancellationToken cancellationToken) =>
            await ExecuteAsync<TOut>(request, NetworkRequestMethod.Get, cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public INetworkResponse<TIn> Post(TRequest request) =>
            Execute<TIn>(request, NetworkRequestMethod.Post);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> PostAsync<TOut>(TRequest request) =>
            await PostAsync<TOut>(request, CancellationToken.None);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> PostAsync<TOut>(TRequest request, CancellationToken cancellationToken) =>
            await ExecuteAsync<TOut>(request, NetworkRequestMethod.Post, cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public INetworkResponse<TIn> Put(TRequest request) =>
            Execute<TIn>(request, NetworkRequestMethod.Put);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> PutAsync<TOut>(TRequest request) =>
            await PutAsync<TOut>(request, CancellationToken.None);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> PutAsync<TOut>(TRequest request, CancellationToken cancellationToken) =>
            await ExecuteAsync<TOut>(request, NetworkRequestMethod.Put, cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public INetworkResponse<TIn> Delete(TRequest request) =>
            Execute<TIn>(request, NetworkRequestMethod.Delete);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> DeleteAsync<TOut>(TRequest request) =>
            await DeleteAsync<TOut>(request, CancellationToken.None);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<INetworkResponse<TOut>> DeleteAsync<TOut>(TRequest request, CancellationToken cancellationToken) =>
            await ExecuteAsync<TOut>(request, NetworkRequestMethod.Delete, cancellationToken);

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        private INetworkResponse<TOut> Execute<TOut>(TRequest request, NetworkRequestMethod method)
        {
            request.Method = method;
            return Execute<TOut>(request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Shipped as part of the public API.")]
        private async Task<INetworkResponse<TOut>> ExecuteAsync<TOut>(TRequest request, NetworkRequestMethod method) =>
            await Task.Run(() => Execute<TOut>(request, method), CancellationToken.None);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<INetworkResponse<TOut>> ExecuteAsync<TOut>(TRequest request, NetworkRequestMethod method, CancellationToken cancellationToken) =>
            await Task.Run(() => Execute<TOut>(request, method), cancellationToken);

        #endregion

    }
}
