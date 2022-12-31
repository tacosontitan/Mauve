using SystemConvert = System.Convert;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents a basic implementation of <see cref="IAdapter{T1, T2}"/> which utilizes <see cref="SystemConvert.ChangeType(object, System.Type)"/>.
    /// </summary>
    /// <typeparam name="T1">Specifies the first type this adapter uses.</typeparam>
    /// <typeparam name="T2">Specifies the second type this adapter uses.</typeparam>
    public class BasicAdapter<T1, T2> : IAdapter<T1, T2>
    {
        /// <summary>
        /// Converts from the first type to the second.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns><see cref="T1"/> converted to <see cref="T2"/>.</returns>
        public T2 Convert(T1 input) =>
            (T2)SystemConvert.ChangeType(input, typeof(T2));
        /// <summary>
        /// Converts from the second type to the first.
        /// </summary>
        /// <param name="input">The input to be converted.</param>
        /// <returns><see cref="T2"/> converted to <see cref="T1"/>.</returns>
        public T1 Convert(T2 input) =>
            (T1)SystemConvert.ChangeType(input, typeof(T1));
    }
}
