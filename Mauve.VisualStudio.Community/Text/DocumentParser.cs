using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

namespace Mauve.VisualStudio.Community.Text
{
    internal abstract class DocumentParser<T>
    {

        #region Properties

        protected Document Document { get; private set; }

        #endregion

        #region Constructor

        public DocumentParser(Document document) => Document = document;

        #endregion

        #region Public Methods

        public abstract T Parse();

        #endregion

    }
}
