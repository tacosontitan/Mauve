using System.Threading;
using System.Threading.Tasks;

namespace Mauve
{
    /// <summary>
    /// An <see langword="interface"/> that exposes methods to handle input.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data used as input for the handler.</typeparam>
    public interface IHandler<T>
    {
        void Handle(T input);
        Task Handle(T input, CancellationToken cancellationToken);
    }
}
