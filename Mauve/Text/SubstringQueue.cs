using System;

namespace Mauve.Text
{
    /// <summary>
    /// Represents a <see cref="SubstringQueue"/> for parsing chunks of a full string.
    /// </summary>
    public sealed class SubstringQueue
    {

        #region Fields

        private int _index = 0;
        private readonly string _fullString = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="SubstringQueue"/> with the specified input string.
        /// </summary>
        /// <param name="value">The string value this queue will be working with.</param>
        public SubstringQueue(string value) => _fullString = value;

        #endregion

        #region Public Methods

        /// <summary>
        /// Resets the queue back to the start of the string.
        /// </summary>
        public void Reset() => _index = 0;
        /// <summary>
        /// Peeks at the string for the specified length from the queue's current index.
        /// </summary>
        /// <param name="length">The number of characters to select from the current index.</param>
        /// <returns>Returns a new string from the current index of the queue through the specified length.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown by .Substring when the requested length plus the current index exceeds the total length of the queue.</exception>
        public string Peek(int length) => _fullString.Substring(_index, length);
        /// <summary>
        /// Takes the specified number of characters from the current index and attempts to convert the result to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to convert the result to.</typeparam>
        /// <param name="length">The number of characters to select from the current index.</param>
        /// <param name="result">The resulting selection converted to the specified type.</param>
        /// <returns>Returns the resulting selection converted to the specified type.</returns>
        public SubstringQueue Next<T>(int length, out T result)
        {
            string substring = _fullString.Substring(_index, length);
            _index += length;

            result = (T)Convert.ChangeType(substring, typeof(T));
            return this;
        }
        /// <summary>
        /// Takes the remaining characters from the input string and attempts to convert the result to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to convert the result to.</typeparam>
        /// <param name="result">The resulting selection converted to the specified type.</param>
        public void Remainder<T>(out T result) => Next(_fullString.Length - _index, out result);
        /// <summary>
        /// Skips the specified number of characters in the queue from the current index.
        /// </summary>
        /// <param name="length">The number of characters to skip.</param>
        public SubstringQueue Skip(int length)
        {
            _index += length;
            return this;
        }

        #endregion

    }
}
