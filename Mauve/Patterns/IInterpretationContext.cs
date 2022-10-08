namespace Mauve.Patterns
{
    /// <summary>
    /// Represents an <see cref="interface"/> that exposes and input for interpretation to an output.
    /// </summary>
    /// <typeparam name="TIn">The type of data for the input.</typeparam>
    /// <typeparam name="TOut">The type of data for the output.</typeparam>
    public interface IInterpretationContext<TIn, TOut>
    {
        /// <summary>
        /// The input for interpretation.
        /// </summary>
        TIn Input { get; set; }
        /// <summary>
        /// The output of the interpretation.
        /// </summary>
        TOut Output { get; set; }
    }
}
