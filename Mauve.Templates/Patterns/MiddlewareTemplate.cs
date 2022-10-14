using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="IMiddleware"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal class $safeitemname$ : IMiddleware
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
        public void Invoke(MiddlewareDelegate next)
        {
            
        }
        /// <inheritdoc/>
        public async Task InvokeAsync(MiddlewareDelegate next) =>
            await InvokeAsync(next, CancellationToken.None);
        /// <inheritdoc/>
        public async Task InvokeAsync(MiddlewareDelegate next, CancellationToken cancellationToken) =>
            await Task.Run(() => Invoke(next), cancellationToken);

        #endregion

    }
}
