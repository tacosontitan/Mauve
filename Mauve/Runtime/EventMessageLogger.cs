using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see langword="abstract"/> implementation of <see cref="ILogger{T}"/> for working with <see cref="EventMessage"/> instances.
    /// </summary>
    /// <inheritdoc/>
    public abstract class EventMessageLogger : ILogger<EventMessage>
    {

        #region Properties

        public IEnumerable<EventType> PermittedEventTypes { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessageLogger"/> instance with all <see cref="EventType"/> values permitted.
        /// </summary>
        public EventMessageLogger()
        {
            PermittedEventTypes = new List<EventType>();
            foreach (EventType eventType in Enum.GetValues(typeof(EventType)))
                if (eventType != EventType.None)
                    PermittedEventTypes = PermittedEventTypes.Append(eventType);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Filters the incoming <see cref="EventMessage"/> based on <see cref="PermittedEventTypes"/>, and writes permitted messages.
        /// </summary>
        /// <param name="input">The <see cref="EventMessage"/> being logged.</param>
        public void Log(EventMessage input) =>
            FilterAndWrite(input);
        /// <summary>
        /// Filters the incoming <see cref="EventMessage"/> based on <see cref="PermittedEventTypes"/>, and writes permitted messages.
        /// </summary>
        /// <param name="input">The <see cref="EventMessage"/> being logged.</param>
        public async Task LogAsync(EventMessage input) =>
            await LogAsync(input, CancellationToken.None);
        /// <summary>
        /// Filters the incoming <see cref="EventMessage"/> based on <see cref="PermittedEventTypes"/>, and writes permitted messages.
        /// </summary>
        /// <param name="input">The <see cref="EventMessage"/> being logged.</param>
        /// <param name="cancellationToken">The cancellation token used to cancel asynchronous processing.</param>
        public async Task LogAsync(EventMessage input, CancellationToken cancellationToken) =>
            await Task.Run(() => FilterAndWrite(input), cancellationToken);
        /// <summary>
        /// Restricts the <see cref="PermittedEventTypes"/> to only those specified in the <paramref name="permittedEventTypeFlags"/> parameter.
        /// </summary>
        /// <param name="permittedEventTypeFlags">The <see cref="EventType"/> flags to permit.</param>
        public void RestrictEventTypes(params EventType[] permittedEventTypeFlags) =>
            PermittedEventTypes = new List<EventType>(permittedEventTypeFlags);

        #endregion

        #region Protected Methods

        protected abstract void WriteMessage(EventMessage message);

        #endregion

        #region Private Methods

        private void FilterAndWrite(EventMessage message)
        {
            if (PermittedEventTypes.Any(type => message.Type.HasFlag(type)))
                WriteMessage(message);
        }

        #endregion

    }
}
