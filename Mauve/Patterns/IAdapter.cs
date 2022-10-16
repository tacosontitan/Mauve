namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see cref="interface"/> that exposes methods for conversion between two concrete types.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type this adapter uses.</typeparam>
    /// <typeparam name="T2">Specifies the second type this adapter uses.</typeparam>
    public interface IAdapter<T1, T2>
    {
        /// <summary>
        /// Converts from the first type to the second.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        T2 Convert(T1 input);
        /// <summary>
        /// Converts from the second type to the first.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        T1 Convert(T2 input);
    }
}
