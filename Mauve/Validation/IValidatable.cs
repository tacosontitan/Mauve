namespace Mauve.Validation
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes methods for validating implementing objects.
    /// </summary>
    public interface IValidatable
    {
        void Validate();
        bool TryValidate();
    }
}
