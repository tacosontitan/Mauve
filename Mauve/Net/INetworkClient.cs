using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Net
{
    public interface INetworkClient
    {
        T Send<T>(INetworkRequest request);
        Task<T> Send<T>(INetworkRequest request, CancellationToken cancellationToken);
    }
}
