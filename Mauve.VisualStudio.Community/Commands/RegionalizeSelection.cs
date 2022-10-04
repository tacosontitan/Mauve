using System;

using EnvDTE;

using Mauve.VisualStudio.Community.Core;

using Microsoft.VisualStudio.Shell;

namespace Mauve.VisualStudio.Community.Commands
{
    internal sealed class RegionalizeSelection : CommandBase<Standardize>
    {

        #region Constructor

        public RegionalizeSelection(AsyncPackage package, OleMenuCommandService commandService) :
            base(0x0102, new Guid("7a54043a-2ca9-4ec1-8313-712c01c181ad"), package, commandService)
        { }

        #endregion

        #region Protected Methods

        protected override void Run(DTE dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            Document activeDocument = dte?.ActiveDocument;
            if (!(activeDocument is null))
            {
                // Get the current selection.
                var textDocument = activeDocument.Object("TextDocument") as TextDocument;
                TextSelection selection = textDocument.Selection;

                // Get the top and bottom edit points.
                EditPoint topEditPoint = selection.TopPoint.CreateEditPoint();
                EditPoint bottomEditPoint = selection.BottomPoint.CreateEditPoint();

                // Insert the region tag at the top and endregion at the bottom.
                topEditPoint.Insert("#region New Region\n\n");
                bottomEditPoint.Insert("\n\n#endregion");
            }
        }

        #endregion

    }
}
