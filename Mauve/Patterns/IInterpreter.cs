namespace Mauve.Patterns
{
    public interface IInterpreter
    {
        void Interpret<TIn, TOut>(IInterpretationContext<TIn, TOut> context);
    }
}
