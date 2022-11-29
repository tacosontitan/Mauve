using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns.Behavioral
{
    public interface IMediator
    {
        T Send<T>(IRequest<T> request);
        Task<T> Send<T>(IRequest<T> request, CancellationToken cancellationToken);
    }
}
