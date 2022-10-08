using System;
using System.IO;

namespace Mauve.Runtime
{
    /// <summary>
    /// Represents an <see cref="EventMessageLogger"/> for writing <see cref="EventMessage"/> data to disk.
    /// </summary>
    /// <inheritdoc/>
    public class EventMessageFileLogger : EventMessageLogger
    {

        #region Fields

        private readonly bool _createDirectory;
        private readonly string _fileName;
        private readonly string _directory;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="EventMessageFileLogger"/> targeting the specified directory and file.
        /// </summary>
        /// <param name="create">Should the directory be created if it doesn't exist?</param>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="directory">The directory where the file should reside.</param>
        public EventMessageFileLogger(bool create, string fileName, string directory)
        {
            _createDirectory = create;
            _fileName = fileName;
            _directory = directory;
        }

        #endregion

        #region Protected Methods

        protected override void WriteMessage(EventMessage message)
        {
            if (_createDirectory && !Directory.Exists(_directory))
                _ = Directory.CreateDirectory(_directory);

            string file = Path.Combine(_directory, _fileName);
            File.WriteAllText(file, $"{DateTime.Now} ({message.Type}): {message.Value}");
        }

        #endregion

    }
}
