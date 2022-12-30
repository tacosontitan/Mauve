using System;
using System.Collections.Generic;
using System.Linq;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="Exception"/> instances.
    /// </summary>
    public static class ExceptionExtensions
    {

        #region Public Methods

        /// <summary>
        /// Recursively flattens the specified exception and all inner exceptions into a single <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="root">The exception to flatten.</param>
        /// <returns>Returns a recursively flattened the specified exception and all inner exceptions into a single <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<Exception> Flatten(this Exception root) => FlattenRecursive(root, new List<Exception>());
        /// <summary>
        /// Recursively flattens the specified exception and all inner exceptions into a single <see cref="IEnumerable{T}"/> and then joins the messages of each exception into a single string.
        /// </summary>
        /// <param name="root">The exception to flatten.</param>
        /// <returns>A <see cref="string"/> containing the flattened exception messages.</returns>
        public static string FlattenMessages(this Exception root) =>
            FlattenMessages(root, " ");
        /// <summary>
        /// Recursively flattens the specified exception and all inner exceptions into a single <see cref="IEnumerable{T}"/> and then joins the messages of each exception into a single string.
        /// </summary>
        /// <param name="root">The exception to flatten.</param>
        /// <param name="separator">The string which should be utilized during the join process.</param>
        /// <returns>A <see cref="string"/> containing the flattened exception messages.</returns>
        public static string FlattenMessages(this Exception root, string separator)
        {
            if (root is null || string.IsNullOrWhiteSpace(separator))
                return string.Empty;

            IEnumerable<Exception> exceptions = root.Flatten();
            IEnumerable<string> messages = exceptions.Select(s => s.Message);
            return string.Join(separator, messages);
        }

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
