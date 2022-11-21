using System;
using System.Collections.Generic;
using System.Linq;

using Mauve.Validation;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="IEnumerable{T}"/> instances.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Iterates over the objects within an <see cref="IEnumerable{T}"/> instance and performs the specified action.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="action">The action to be invoked for each object in the <see cref="IEnumerable{T}"/> instance.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection is null)
                return;

            foreach (T item in collection)
                action(item);
        }
        /// <summary>
        /// Gets the index of a specified <see cref="T"/> in the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="searchValue">The element to search for.</param>
        /// <returns>The index of a specified <see cref="T"/>, otherwise <c>-1</c>.</returns>
        public static int IndexOf<T>(this IEnumerable<T> collection, T searchValue)
        {
            if (collection == null)
                return -1;

            int index = 0;
            foreach (T item in collection)
            {
                if (item?.Equals(searchValue) == true)
                    return index;

                index++;
            }

            return -1;
        }
        /// <summary>
        /// Gets the next element in the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="item">The element to search for.</param>
        /// <returns>Returns the next element in the <see cref="IEnumerable{T}"/> if one is available.</returns>
        /// <exception cref="NotFoundException">The specified <paramref name="item"/> is not found in the collection.</exception>
        /// <exception cref="IndexOutOfRangeException">There is no element after the specified <paramref name="item"/>.</exception>
        public static T Next<T>(this IEnumerable<T> collection, T item)
        {
            if (collection is null)
                return default;

            int index = collection.IndexOf(item);
            return index == -1
                ? throw new NotFoundException()
                : index + 1 > collection.Count()
                    ? throw new IndexOutOfRangeException("There is no element after the specified item.")
                    : collection.ElementAt(index + 1);
        }
        /// <summary>
        /// Gets the next element in the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="item">The element to search for.</param>
        /// <returns>Returns the next element in the <see cref="IEnumerable{T}"/> if one is available.</returns>
        public static T NextOrDefault<T>(this IEnumerable<T> collection, T item)
        {
            try
            {
                return collection is null
                    ? default
                    : collection.Next(item);
            } catch
            {
                return default;
            }
        }
        /// <summary>
        /// Gets the previous element in the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="item">The element to search for.</param>
        /// <returns>Returns the previous element in the <see cref="IEnumerable{T}"/> if one is available.</returns>
        /// <exception cref="NotFoundException">The specified <paramref name="item"/> is not found in the collection.</exception>
        /// <exception cref="IndexOutOfRangeException">There is no element before the specified <paramref name="item"/>.</exception>
        public static T Previous<T>(this IEnumerable<T> collection, T item)
        {
            if (collection is null)
                return default;

            int index = collection.IndexOf(item);
            return index == -1
                ? throw new NotFoundException()
                : index - 1 > collection.Count()
                    ? throw new IndexOutOfRangeException("There is no element before the specified item.")
                    : collection.ElementAt(index - 1);
        }
        /// <summary>
        /// Gets the previous element in the specified <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object contained in the <see cref="IEnumerable{T}"/> instance.</typeparam>
        /// <param name="collection">The collection of objects to work with.</param>
        /// <param name="item">The element to search for.</param>
        /// <returns>Returns the previous element in the <see cref="IEnumerable{T}"/> if one is available.</returns>
        public static T PreviousOrDefault<T>(this IEnumerable<T> collection, T item)
        {
            try
            {
                return collection.Previous(item);
            } catch
            {
                return default;
            }
        }
    }
}
