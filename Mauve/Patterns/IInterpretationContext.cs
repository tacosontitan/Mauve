namespace Mauve.Patterns
{
    public interface IInterpretationContext<TIn, TOut>
    {
        TIn Input { get; set; }
        TOut Output { get; set; }
    }
}
