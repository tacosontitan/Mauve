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

        /// <summary>
        /// Creates a new <see cref="Handler{T}"/> instance with the specified request.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        public $safeitemname$(T request) :
            base(request)
        { }
        /// <summary>
        /// Creates a new <see cref="Handler{T}"/> instance with the specified request and followup <see cref="Handler{T}"/>.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <param name="nextHandler">The next <see cref="Handler{T}"/> in the chain of responsibility.</param>
        public $safeitemname$(T request, Handler<T> nextHandler) :
            base(request, nextHandler)
        { }

        #endregion
        
        #region Protected Methods
        
        /// <inheritdoc/>
        protected override bool TryHandleRequest(T request) => throw new NotImplementedException();

        #endregion

    }
}
