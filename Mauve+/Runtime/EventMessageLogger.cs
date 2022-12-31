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

        #region Fields

        private readonly IFilterStrategy<EventMessage> _filterStrategy;

        #endregion

        #region Properties

        /// <summary>
        /// The highest flag permitted to be logged by the <see cref="ILogger{T}"/> instance.
        /// </summary>
        public EventType Threshold { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessageLogger"/> instance.
        /// </summary>
        public EventMessageLogger() { }
        /// <summary>
        /// Creates a new <see cref="EventMessageLogger"/> instance.
        /// </summary>
        /// <param name="filterStrategy">The filter strategy that should be applied to incoming messages.</param>
        public EventMessageLogger(IFilterStrategy<EventMessage> filterStrategy) =>
            _filterStrategy = filterStrategy;

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

        #endregion

        #region Protected Methods

        /// <summary>
        /// Writes the <see cref="EventMessage"/>.
        /// </summary>
        /// <param name="message">The message to write.</param>
        protected abstract void WriteMessage(EventMessage message);

        #endregion

        #region Private Methods

        private void FilterAndWrite(EventMessage message)
        {
            if (_filterStrategy is null)
                WriteMessage(message);
            else
            {
                EventMessage filterResult = _filterStrategy.Filter(message);
                if (filterResult is null)
                    return;

                WriteMessage(message);
            }
        }

        #endregion

    }
}
