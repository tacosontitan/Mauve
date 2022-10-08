using System.Collections.Generic;

namespace Mauve.Patterns
{
    public class HandlerChainBuilder<T> : IHandlerChainBuilder<T>
    {

        #region Fields

        private readonly List<Handler<T>> _handlers;

        #endregion

        #region Constructor

        public HandlerChainBuilder() => _handlers = new List<Handler<T>>();

        #endregion

        #region Public Methods

        public Handler<T> Build() => BuildHandlerChainRecursive(0);
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
