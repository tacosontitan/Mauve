using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns.Behavioral
{
    public interface IMediator
    {
        T Send<T>(IMediatorRequest<T> request);
        Task<T> Send<T>(IMediatorRequest<T> request, CancellationToken cancellationToken);
    }
}
