namespace Mauve.Patterns
{
    /// <summary>
    /// Represents a <see langword="class"/> that descibes a dependency.
    /// </summary>
    public class DependencyDescriptor
    {
        /// <summary>
        /// The identifier used to describe the dependency.
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// The value of the dependency being described.
        /// </summary>
        public object Value { get; set; }
    }
}
