using Mauve.Patterns.Behavioral;

namespace Mauve.Lacework
{
    public interface ILaceworkRequestHandler<TIn, TOut> : IMediatorRequestHandler<TIn, TOut>
    {
    }
}
