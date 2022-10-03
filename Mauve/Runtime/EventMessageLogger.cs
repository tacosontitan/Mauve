using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Runtime
{
    public abstract class EventMessageLogger : ILogger<EventMessage>
    {

        #region Properties

        public IEnumerable<EventType> PermittedEventTypes { get; set; }

        #endregion

        #region Constructor

        public EventMessageLogger()
        {
            PermittedEventTypes = new List<EventType>();
            foreach (EventType eventType in Enum.GetValues(typeof(EventType)))
                if (eventType != EventType.None)
                    PermittedEventTypes = PermittedEventTypes.Append(eventType);
        }

        #endregion

        #region Public Methods

        public void Log(EventMessage input) => FilterAndWrite(input);
        public async Task LogAsync(EventMessage input) => await Task.Run(() => FilterAndWrite(input));
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
