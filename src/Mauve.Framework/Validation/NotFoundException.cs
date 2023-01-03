using System;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see cref="Exception"/> that is thrown when a resource is not found.
    /// </summary>
    public sealed class NotFoundException : Exception
    {

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="NotAuthorizedException"/>.
        /// </summary>
        public NotFoundException() :
            base("Not found.")
        { }
        /// <summary>
        /// Creates a new instance of <see cref="NotAuthorizedException"/> with details regarding the requested resource.
        /// </summary>
        /// <param name="details">Any details regarding the requested resource.</param>
        public NotFoundException(string details) :
            base($"Not found. {details}")
        { }

        #endregion

    }
}
