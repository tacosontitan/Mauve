namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see langword="interface"/> that exposes a method for interpreting an <see cref="IInterpretationContext{TIn, TOut}"/>.
    /// </summary>
    public interface IInterpreter
    {
        /// <summary>
        /// Interprets the specified <see cref="IInterpretationContext{TIn, TOut}"/>.
        /// </summary>
        /// <typeparam name="TIn">The type of data for the input.</typeparam>
        /// <typeparam name="TOut">The type of data for the output.</typeparam>
        /// <param name="context">The context of the interpretation containing the input.</param>
        void Interpret<TIn, TOut>(IInterpretationContext<TIn, TOut> context);
    }
}
