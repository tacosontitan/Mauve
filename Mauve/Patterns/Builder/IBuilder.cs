namespace Mauve.Patterns.Builder
{
    /// <summary>
    /// Represents an <see cref="IBuilder{T}"/> interface that defines a method of building an instace of <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type this interface will build.</typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builds a new instance of <see cref="T"/>.
        /// </summary>
        /// <returns>Returns a new instance of <see cref="T"/>.</returns>
        T Build();
    }
}
