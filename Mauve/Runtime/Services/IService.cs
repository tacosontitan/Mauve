
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace Mauve.Runtime.Services
{
    /// <summary>
    /// An <see langword="interface"/> which represents a basic service.
    /// </summary>
    public interface IService
    {

        #region General Methods

        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="dependencies">The <see cref="IDependencyCollection"/> maintained by the service.</param>
        /// <param name="pipeline">The <see cref="IServicePipeline{T}"/> utilized to execute requests.</param>
        void Configure(IDependencyCollection dependencies, IServicePipeline<IRequest> pipeline);

        #endregion

        #region Delete Methods

        void Delete<T>(T input);
        Task Delete<T>(T input, CancellationToken cancellationToken);
        void Delete<T>(IRequest request);
        Task Delete<T>(IRequest request, CancellationToken cancellationToken);

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
        T Patch<T>(IRequest request);
        Task<T> Patch<T>(T input, CancellationToken cancellationToken);
        Task<T> Patch<T>(IRequest request, CancellationToken cancellationToken);

        #endregion

        #region Post Methods

        T Post<T>(T input);
        T Post<T>(IRequest request);
        Task<T> Post<T>(T input, CancellationToken cancellationToken);
        Task<T> Post<T>(IRequest request, CancellationToken cancellationToken);

        #endregion

        #region Put Methods

        T Put<T>(T input);
        T Put<T>(IRequest request);
        Task<T> Put<T>(T input, CancellationToken cancellationToken);
        Task<T> Put<T>(IRequest request, CancellationToken cancellationToken);

        #endregion

    }
}
