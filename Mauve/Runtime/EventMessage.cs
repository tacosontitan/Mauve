namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see cref="EventMessage"/> containing an <see cref="EventType"/> and a <see cref="string"/> value.
    /// </summary>
    public class EventMessage
    {

        #region Properties

        /// <summary>
        /// The <see cref="EventType"/> associated with this message.
        /// </summary>
        public EventType Type { get; set; }
        /// <summary>
        /// The message value.
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessage"/> instance.
        /// </summary>
        public EventMessage() { }
        /// <summary>
        /// Creates a new <see cref="EventMessage"/> instance with the specified value.
        /// </summary>
        /// <param name="message">The value of the message.</param>
        public EventMessage(string message) : this() => Value = message;
        /// <summary>
        /// Creates a new <see cref="EventMessage"/> instance with the specified <see cref="EventType"/> and value.
        /// </summary>
        /// <param name="type">The <see cref="EventType"/> associated with the message.</param>
        /// <param name="message">The value of the message.</param>
        public EventMessage(EventType type, string message) : this(message) => Type = type;

        #endregion

    }
}
