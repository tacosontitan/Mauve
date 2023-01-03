using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace $rootnamespace$
{
    /// <summary>
    /// Represents an implementation of <see cref="IFactory{T}"/> that...
    /// </summary>
    /// <inheritdoc/>
    internal sealed class $safeitemname$ : IFactory<T>
    {

        #region Public Methods

        /// <inheritdoc/>
        public T Create() => throw new NotImplementedException();

        #endregion

    }
}
