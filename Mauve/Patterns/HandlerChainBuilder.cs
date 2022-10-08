using System.Collections.Generic;

namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see cref="IHandlerChainBuilder{T}"/> instance capable of building a chain of <see cref="Handler{T}"/> instances.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HandlerChainBuilder<T> : IHandlerChainBuilder<T>
    {

        #region Fields

        private readonly List<Handler<T>> _handlers;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="HandlerChainBuilder{T}"/> instance.
        /// </summary>
        public HandlerChainBuilder() => _handlers = new List<Handler<T>>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the chain of <see cref="Handler{T}"/>.
        /// </summary>
        /// <returns>The first <see cref="Handler{T}"/> in the chain.</returns>
        public Handler<T> Build() => BuildHandlerChainRecursive(0);
        /// <summary>
        /// Tells the builder that the specified handler should be added next in the chain.
        /// </summary>
        /// <param name="handler">The handler to add to the chain.</param>
        /// <returns>Returns the current <see cref="IHandlerChainBuilder{T}"/> instance.</returns>
        public IHandlerChainBuilder<T> Use(Handler<T> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        #endregion

        #region Private Methods

        private Handler<T> BuildHandlerChainRecursive(int index)
        {
            // If we have no more handlers, we're done.
            if (index > _handlers.Count)
                return null;

            // Get the current handler and set the next handler using recursion.
            Handler<T> handler = _handlers[index];
            handler.SetNextHandler(BuildHandlerChainRecursive(++index));
            return handler;
        }

        #endregion

    }
}
