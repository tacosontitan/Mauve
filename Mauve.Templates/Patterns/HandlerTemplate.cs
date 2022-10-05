using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="Handler{T}"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal sealed class $safeitemname$ : Handler<T>
    {

        #region Constructors

        public $safeitemname$(T request) : base(request)
        {
        }
        public $safeitemname$(T request, Handler<T> nextHandler) : base(request, nextHandler)
        {
        }

        #endregion

        #region Protected Methods

        protected override bool TryHandleRequest(T request) => throw new NotImplementedException();

        #endregion

    }
}
