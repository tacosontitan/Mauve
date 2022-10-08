using System;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see cref="Exception"/> that is thrown when something is not authorized.
    /// </summary>
    public sealed class NotAuthorizedException : Exception
    {

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="NotAuthorizedException"/>.
        /// </summary>
        public NotAuthorizedException() :
            base("Not authorized.")
        { }
        /// <summary>
        /// Creates a new instance of <see cref="NotAuthorizedException"/> with details regarding authorization.
        /// </summary>
        /// <param name="details">Any details regarding authorization.</param>
        public NotAuthorizedException(string details) :
            base($"Not authorized. {details}")
        { }

        #endregion

    }
}
