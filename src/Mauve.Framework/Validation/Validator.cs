namespace Mauve.Validation
{
    /// <summary>
    /// Represents a <see langword="class"/> that exposes methods for validating objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data the validator is validating.</typeparam>
    public abstract class Validator<T>
    {

        #region Public Methods

        /// <summary>
        /// Attempts to validate the input for the <see cref="Validator{T}"/> instance.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        /// <returns><see langword="true"/> if the input is valid, otherwise <see langword="false"/>.</returns>
        public bool TryValidate(T input)
        {
            try
            {
                Validate(input);
                return true;
            } catch
            {
                return false;
            }
        }
        /// <summary>
        /// Validates the input for the <see cref="Validator{T}"/> instance.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        public abstract void Validate(T input);

        #endregion

    }
}
