using System;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see cref="Exception"/> representing an issue with validation.
    /// </summary>
    public class ValidationException : Exception
    {

        #region Properties

        /// <summary>
        /// The result of the validation process.
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="ValidationException"/> instance with the specified <see cref="ValidationResult"/> and message.
        /// </summary>
        /// <param name="validationResult">The result of the validation process.</param>
        /// <param name="message">The message explaining what happened.</param>
        public ValidationException(ValidationResult validationResult, string message) :
            base(message) =>
                ValidationResult = validationResult;

        #endregion

    }
}
