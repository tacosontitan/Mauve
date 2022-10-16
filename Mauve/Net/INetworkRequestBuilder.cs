using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace Mauve.Net
{
    public interface INetworkRequestBuilder<TRequest, TData> : IBuilder<TRequest>
        where TRequest : INetworkRequest<TData>
    {
        /// <summary>
        /// Adds the specified header to the <see cref="INetworkRequest{T}"/>.
        /// </summary>
        /// <typeparam name="T">Specifies the type of data the value for the header is.</typeparam>
        /// <param name="key">The key for the header.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>Returns the current builder instance.</returns>
        INetworkRequestBuilder<TRequest, TData> UseHeader<T>(string key, T value);
    }
}
