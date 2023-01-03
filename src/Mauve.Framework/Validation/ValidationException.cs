using System;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see cref="Exception"/> expressing an issue with validation.
    /// </summary>
    public class ValidationException : Exception
    {

        #region Properties

        /// <summary>
        /// The input that failed validation.
        /// </summary>
        public object Input { get; }
        /// <summary>
        /// The expectation the validation failed to meet.
        /// </summary>
        public object Expectation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="ValidationException"/> instance with the specified <see cref="ValidationResult"/> and message.
        /// </summary>
        /// <param name="input">The input that failed validation.</param>
        /// <param name="expectation">The expectation the validation failed to meet.</param>
        /// <param name="message">The message explaining what happened.</param>
        public ValidationException(object input, object expectation, string message) :
            base(message)
        {
            Input = input;
            Expectation = expectation;
        }

        #endregion

    }
}
