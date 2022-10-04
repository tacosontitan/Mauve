using System;
using System.Windows.Forms;

using EnvDTE;

using Mauve.VisualStudio.Community.Core;

using Microsoft.VisualStudio.Shell;

namespace Mauve.VisualStudio.Community.Commands
{
    internal sealed class CopyUnixNow : CommandBase<CopyUnixNow>
    {

        #region Constructor

        public CopyUnixNow(AsyncPackage package, OleMenuCommandService commandService) :
            base(0x0101, new Guid("7a54043a-2ca9-4ec1-8313-712c01c181ad"), package, commandService)
        { }

        #endregion

        #region Protected Methods

        protected override void Run(DTE dte) => Clipboard.SetText(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString());

        #endregion

    }
}
