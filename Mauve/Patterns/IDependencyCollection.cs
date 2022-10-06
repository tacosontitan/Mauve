using System.Collections.Generic;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes methods for manipulating a collection of dependencies.
    /// </summary>
    /// <remarks>Derives from <see cref="IList{T}"/>.</remarks>
    public interface IDependencyCollection : IList<DependencyDescriptor>
    {
        /// <summary>
        /// Adds an instance of the specified type to the collection.
        /// </summary>
        /// <typeparam name="T">The type of the instance to add.</typeparam>
        /// <param name="singleton">The instance to add to the collection.</param>
        /// <returns>Returns the current <see cref="IDependencyCollection"/>.</returns>
        IDependencyCollection AddSingleton<T>(T singleton);
    }
}
