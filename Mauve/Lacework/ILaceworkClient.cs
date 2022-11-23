using System;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Net;

namespace Mauve.Lacework
{
    public interface ILaceworkClient
    {
        T Get<T>(Func<T, bool> predicate);
        T Send<T>(INetworkRequest request);
        Task<T> Send<T>(INetworkRequest request, CancellationToken cancellationToken);
    }
}
