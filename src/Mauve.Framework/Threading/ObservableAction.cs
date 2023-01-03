namespace Mauve.Threading
{
    /// <summary>
    /// Represents an action that can be observed.
    /// </summary>
    internal class ObservableAction
    {

        #region Events

        /// <summary>
        /// The event invoked when an <see cref="ObservableAction"/> sends messages to consumers.
        /// </summary>
        public event ObservableActionEventHandler MessageReceived;
        /// <summary>
        /// Represents the method that will handle events for <see cref="ObservableAction"/> instances.
        /// </summary>
        /// <param name="sender">The <see cref="ObservableAction"/> that raised the event.</param>
        /// <param name="e">The <see cref="ObservableActionEventArgs"/> associated with the event.</param>
        public delegate void ObservableActionEventHandler(ObservableAction sender, ObservableActionEventArgs e);

        #endregion

    }
}
