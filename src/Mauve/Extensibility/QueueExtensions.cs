using System;
using System.Collections.Generic;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="Queue{T}"/> instances.
    /// </summary>
    public static class QueueExtensions
    {
        /// <summary>
        /// Dequeues the specified number of elements from the queue.
        /// </summary>
        /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
        /// <param name="queue">The <see cref="Queue{T}"/> instance to retrieve elements from.</param>
        /// <param name="count">The number of elements to retrieve.</param>
        /// <returns>Returns the specified number of elements to retrieve.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The requested number of elements exceeds the number of remaining elements in the queue.</exception>
        public static IEnumerable<T> Dequeue<T>(this Queue<T> queue, int count)
        {
            if (queue is null)
                return null;

            // Validate the requested count.
            if (count > queue.Count)
                throw new ArgumentOutOfRangeException("The requested number of elements exceeds the number of remaining elements in the queue.");

            // Fetch elements from the queue.
            var result = new List<T>();
            while (count-- > 0)
                result.Add(queue.Dequeue());

            // Return the result.
            return result;
        }
    }
}
