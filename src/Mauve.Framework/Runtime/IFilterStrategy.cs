namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see langword="interface"/> for filtering data.
    /// </summary>
    /// <typeparam name="T">Specifies the type this filter strategy applies to.</typeparam>
    public interface IFilterStrategy<T>
    {
        /// <summary>
        /// Filters the incoming data.
        /// </summary>
        /// <param name="input">The data to filter.</param>
        /// <returns>The filtered data.</returns>
        T Filter(T input);
    }
}
