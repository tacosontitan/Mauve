namespace Mauve.Runtime
{
    public class EventMessage
    {

        #region Properties

        public EventType Type { get; set; }
        public string Value { get; set; }

        #endregion

        #region Constructor

        public EventMessage() { }
        public EventMessage(string message) : this() => Value = message;
        public EventMessage(EventType type, string message) : this(message) => Type = type;

        #endregion

    }
}
