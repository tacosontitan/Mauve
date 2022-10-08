using System;

namespace Mauve
{
    /// <summary>
    /// Represents an <see langword="enum"/> used to classify event messages.
    /// </summary>
    [Flags]
    public enum EventType : long
    {
        /// <summary>
        /// Represents an unspecified or unsupported <see cref="EventType"/>.
        /// </summary>
        None = 0,
        /// <summary>
        /// Represents an event indicating that consumers should be alerted.
        /// </summary>
        Alert = 1L << 0,
        /// <summary>
        /// Represents an event indicating a runtime exception.
        /// </summary>
        Exception = 1L << 1,
        /// <summary>
        /// Represents an event indicating an error.
        /// </summary>
        Error = 1L << 2,
        /// <summary>
        /// Represents an event indicating a warning.
        /// </summary>
        Warning = 1L << 3,
        /// <summary>
        /// Represents an event indicating success.
        /// </summary>
        Success = 1L << 4,
        /// <summary>
        /// Represents an event conveying general information.
        /// </summary>
        Information = 1L << 5,
        /// <summary>
        /// Represents an event conveying only progress information.
        /// </summary>
        Progress = 1L << 6,
        /// <summary>
        /// Represents a diagnostic event.
        /// </summary>
        Diagnostic = 1L << 62,
    }
}
