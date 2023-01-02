using System.Threading;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="IMiddleware"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal class $safeitemname$ : IMiddleware<T>
    {

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="$safeitemname$"/>.
        /// </summary>
        public $safeitemname$()
        {

        }

#endregion

#region Public Methods

/// <inheritdoc/>
public void Invoke(T input, MiddlewareDelegate<object> next)
{

}
/// <inheritdoc/>
public async Task InvokeAsync(T input, MiddlewareDelegate<object> next) =>
    await InvokeAsync(next, CancellationToken.None);
/// <inheritdoc/>
public async Task InvokeAsync(T input, MiddlewareDelegate<object> next, CancellationToken cancellationToken) =>
    await Task.Run(() => Invoke(next), cancellationToken);

        #endregion

    }
}