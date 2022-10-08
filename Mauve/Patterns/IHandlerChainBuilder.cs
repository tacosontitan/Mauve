namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see cref="interface"/> that exposes methods to build a chain of <see cref="Handler{T}"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of request the <see cref="Handler{T}"/> chain will work with.</typeparam>
    public interface IHandlerChainBuilder<T> : IBuilder<Handler<T>>
    {
        /// <summary>
        /// Tells the builder that the specified handler should be added next in the chain.
        /// </summary>
        /// <param name="handler">The handler to add to the chain.</param>
        /// <returns>Returns the current <see cref="IHandlerChainBuilder{T}"/> instance.</returns>
        IHandlerChainBuilder<T> Use(Handler<T> handler);
    }
}
