﻿using System;
using System.IO;

namespace Mauve.Runtime
{
    public class EventMessageFileLogger : EventMessageLogger
    {

        #region Fields

        private readonly bool _createDirectory;
        private readonly string _fileName;
        private readonly string _directory;

        #endregion

        #region Constructor

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
