using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    public interface INetworkService
    {

        #region Delete Methods

        void Delete<T>(T input);
        Task Delete<T>(T input, CancellationToken cancellationToken);
        void Delete<T>(IRequest<T> request);
        Task Delete<T>(IRequest<T> request, CancellationToken cancellationToken);

        #endregion

        #region Get Methods

        IEnumerable<T> Get<T>();
        IEnumerable<T> Get<T>(IRequest<T> request);
        IEnumerable<T> Get<T>(Predicate<T> predicate);
        Task<IEnumerable<T>> Get<T>(CancellationToken cancellationToken);
        Task<IEnumerable<T>> Get<T>(IRequest<T> request, CancellationToken cancellationToken);
        Task<IEnumerable<T>> Get<T>(Predicate<T> predicate, CancellationToken cancellationToken);

        #endregion

        #region Patch Methods

        T Patch<T>(T input);
        T Patch<T>(IRequest<T> request);
        Task<T> Patch<T>(T input, CancellationToken cancellationToken);
        Task<T> Patch<T>(IRequest<T> request, CancellationToken cancellationToken);

        #endregion

        #region Post Methods

        T Post<T>(T input);
        T Post<T>(IRequest<T> request);
        Task<T> Post<T>(T input, CancellationToken cancellationToken);
        Task<T> Post<T>(IRequest<T> request, CancellationToken cancellationToken);

        #endregion

        #region Put Methods

        T Put<T>(T input);
        T Put<T>(IRequest<T> request);
        Task<T> Put<T>(T input, CancellationToken cancellationToken);
        Task<T> Put<T>(IRequest<T> request, CancellationToken cancellationToken);

        #endregion

    }
}
