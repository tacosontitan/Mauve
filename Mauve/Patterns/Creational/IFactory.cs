namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that defines the basics of the <see href="https://en.wikipedia.org/wiki/Factory_method_pattern">factory pattern</see>.
    /// </summary>
    /// <typeparam name="T">The type of object this factory creates.</typeparam>
    public interface IFactory<T>
    {
        /// <summary>
        /// Creates an instance of <see cref="T"/>.
        /// </summary>
        /// <returns>Returns a new instance of <see cref="T"/>.</returns>
        T Create();
    }
}
