using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

using EnvDTE;

using Mauve.VisualStudio.Community.Commands;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using ShellPackage = Microsoft.VisualStudio.Shell.Package;

namespace Mauve.VisualStudio.Community.Core
{
    internal abstract class CommandBase<T> where T : CommandBase<T>
    {

        #region Properties

        /// <summary>
        /// Command ID.
        /// </summary>
        protected static int CommandId { get; private set; }
        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        protected static Guid CommandSet { get; private set; }
        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        protected static AsyncPackage Package { get; private set; }
        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static T Instance { get; private set; }
        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        protected IAsyncServiceProvider ServiceProvider => Package;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanseAndSave"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        protected CommandBase(int id, Guid set, AsyncPackage package, OleMenuCommandService commandService)
        {
            CommandId = id;
            CommandSet = set;

            Package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in CleanseAndSave's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);
            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = (T)Activator.CreateInstance(typeof(T), package, commandService);
        }

        #endregion

        #region Protected Methods

        protected void Alert(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // Set the title.
            string title = "Mauve";

            // Show a message box to prove we were here
            _ = VsShellUtilities.ShowMessageBox(
                Package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
        protected abstract void Run(DTE dte);

        #endregion

        #region Private Methods

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var dte = ShellPackage.GetGlobalService(typeof(SDTE)) as DTE;
            Run(dte);
        }

        #endregion

    }
}
