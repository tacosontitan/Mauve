namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that defines methods for supporting the memento design pattern.
    /// </summary>
    /// <typeparam name="T">The type of data this interface works with.</typeparam>
    internal interface IRestorable<T>
    {
        /// <summary>
        /// Creates a memento of the implementer's current state.
        /// </summary>
        /// <returns>Returns a memento of the implementer's current state.</returns>
        T CreateMemento();
        /// <summary>
        /// Restores state from a memento.
        /// </summary>
        /// <param name="memento">The memento to restore from.</param>
        void Restore(T memento);
    }
}
