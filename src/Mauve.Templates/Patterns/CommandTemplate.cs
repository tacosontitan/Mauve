using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="ICommand"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal sealed class $safeitemname$ : ICommand
    {

        #region Public Methods

        /// <inheritdoc/>
        public void Execute() => throw new NotImplementedException();
        /// <inheritdoc/>
        public void Rollback() => throw new NotImplementedException();

        #endregion

    }
}
