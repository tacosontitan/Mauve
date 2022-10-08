namespace Mauve.Patterns
{
    public interface IHandlerChainBuilder<T> : IBuilder<Handler<T>>
    {
        IHandlerChainBuilder<T> Use(Handler<T> handler);
    }
}
