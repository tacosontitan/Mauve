using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;

using EnvDTE;

using Mauve.VisualStudio.Community.Core;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using Task = System.Threading.Tasks.Task;

namespace Mauve.VisualStudio.Community.Commands
{
    internal sealed class Standardize : CommandBase<Standardize>
    {

        #region Constructor

        public Standardize(AsyncPackage package, OleMenuCommandService commandService) :
            base(0x0100, new Guid("7a54043a-2ca9-4ec1-8313-712c01c181ad"), package, commandService)
        { }

        #endregion

        #region Protected Methods

        protected override void Run(DTE dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            Document activeDocument = dte?.ActiveDocument;
            if (!(activeDocument is null))
            {
                // Get the current contents of the document.
                //var textDocument = activeDocument.Object("TextDocument") as TextDocument;
                //EditPoint editPoint = textDocument.StartPoint.CreateEditPoint();
                //string documentText = editPoint.GetText(textDocument.EndPoint);

                // Remove and sort usings.
                activeDocument.DTE.ExecuteCommand("Edit.RemoveAndSort");

                // Format document.
                activeDocument.DTE.ExecuteCommand("Edit.FormatDocument");

                // Save document.
                _ = activeDocument.Save();

                // Notify that we've finished our work.
                Alert("Standardization complete.");
            }
        }

        #endregion

    }
}
