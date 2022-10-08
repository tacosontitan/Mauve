using System;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see cref="EventMessageLogger"/> for writing <see cref="EventMessage"/> data using a <see cref="Console"/>.
    /// </summary>
    /// <inheritdoc/>
    public class EventMessageConsoleLogger : EventMessageLogger
    {

        #region Fields

        private ConsoleColor _errorColor;
        private ConsoleColor _warningColor;
        private ConsoleColor _successColor;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessageConsoleLogger"/> instance.
        /// </summary>
        public EventMessageConsoleLogger() : base() { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Specifies the colors to use for core <see cref="EventType"/> flags.
        /// </summary>
        /// <param name="errorColor">The <see cref="ConsoleColor"/> to use as the foreground color when <see cref="EventType.Error"/> or <see cref="EventType.Exception"/> is present.</param>
        /// <param name="warningColor">The <see cref="ConsoleColor"/> to use as the foreground color when <see cref="EventType.Warning"/> is present.</param>
        /// <param name="successColor">The <see cref="ConsoleColor"/> to use as the foreground color when <see cref="EventType.Success"/> is present.</param>
        public void UseColors(ConsoleColor errorColor, ConsoleColor warningColor, ConsoleColor successColor)
        {
            _errorColor = errorColor;
            _warningColor = warningColor;
            _successColor = successColor;
        }

        #endregion

        #region Protected Methods

        protected override void WriteMessage(EventMessage message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            try
            {
                // Change the foreground color based on the type of message received.
                if (message.Type.HasFlag(EventType.Exception) || message.Type.HasFlag(EventType.Error))
                    Console.ForegroundColor = _errorColor;
                else if (message.Type.HasFlag(EventType.Warning))
                    Console.ForegroundColor = _warningColor;
                else if (message.Type.HasFlag(EventType.Success))
                    Console.ForegroundColor = _successColor;

                // Write the message to the console.
                Console.WriteLine(message.Value);
            } finally
            {
                Console.ForegroundColor = currentColor;
            }
        }

        #endregion

    }
}
