using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Extensibility
{
    public static class ExceptionExtensions
    {

        #region Public Methods

        public static IEnumerable<Exception> Flatten(this Exception root) => FlattenRecursive(root, new List<Exception>());

        #endregion

        #region Private Methods

        private static IEnumerable<Exception> FlattenRecursive(Exception target, IEnumerable<Exception> flattenedExceptions)
        {
            // Append the target, then capture the inner exception and return.
            if (!(target is null))
            {
                flattenedExceptions = flattenedExceptions.Append(target);
                flattenedExceptions = FlattenRecursive(target.InnerException, flattenedExceptions);
            }

            // If the target is null then there is nothing to append and no need to dive further.
            return flattenedExceptions;
        }

        #endregion

    }
}
