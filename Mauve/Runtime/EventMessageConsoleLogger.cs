using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Runtime
{
    public class EventMessageConsoleLogger : EventMessageLogger
    {

        #region Fields

        private ConsoleColor _errorColor;
        private ConsoleColor _warningColor;
        private ConsoleColor _successColor;

        #endregion

        #region Constructor

        public EventMessageConsoleLogger() : base() { }

        #endregion

        #region Public Methods

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
