using System;

using Mauve.Runtime;

namespace Mauve.Threading
{
    /// <summary>
    /// Represents <see cref="EventArgs"/> for an <see cref="ObservableAction"/>.
    /// </summary>
    public class ObservableActionEventArgs : EventArgs
    {

        #region Properties

        /// <summary>
        /// Any data associated with the event.
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// The <see cref="EventMessage"/> describing the event.
        /// </summary>
        public EventMessage Message { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="ObservableActionEventArgs"/> instance.
        /// </summary>
        /// <param name="message">The <see cref="EventMessage"/> describing the event</param>
        public ObservableActionEventArgs(EventMessage message) :
            this(message, null)
        { }
        /// <summary>
        /// Creates a new <see cref="ObservableActionEventArgs"/> instance.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/> associated with the <see cref="EventMessage"/>.</param>
        /// <param name="message">The message describing the event.</param>
        public ObservableActionEventArgs(EventType eventType, string message) :
            this(eventType, message, null)
        { }
        /// <summary>
        /// Creates a new <see cref="ObservableActionEventArgs"/> instance.
        /// </summary>
        /// <param name="eventType">The <see cref="EventType"/> associated with the <see cref="EventMessage"/>.</param>
        /// <param name="message">The message describing the event.</param>
        /// <param name="data">Any data associated with the event.</param>
        public ObservableActionEventArgs(EventType eventType, string message, object data) :
            this(new EventMessage(eventType, message), data)
        { }
        /// <summary>
        /// Creates a new <see cref="ObservableActionEventArgs"/> instance.
        /// </summary>
        /// <param name="message">The <see cref="EventMessage"/> describing the event.</param>
        /// <param name="data">Any data associated with the event.</param>
        public ObservableActionEventArgs(EventMessage message, object data)
        {
            Message = message;
            Data = data;
        }

        #endregion

    }
}
