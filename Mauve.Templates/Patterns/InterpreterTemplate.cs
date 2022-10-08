using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="IInterpreter"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal sealed class $safeitemname$ : IInterpreter
    {

        #region Public Methods

        /// <inheritdoc/>
        public void Interpret<TIn, TOut>(IInterpretationContext<TIn, TOut> context);

        #endregion

    }
}
