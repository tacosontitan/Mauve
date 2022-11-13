namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes methods for validating implementing objects.
    /// </summary>
    public interface IValidatable
    {
        void Validate();
        /// <summary>
        /// Attempts to validate the implementing object.
        /// </summary>
        /// <returns><see langword="true"/> if validation was successful, otherwise <see langword="false"/>.</returns>
        bool TryValidate();
    }
}
