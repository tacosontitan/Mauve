using System;
using System.Data;

namespace Mauve.Net
{
    /// <summary>
    /// An <see cref="interface"/> which represents a network connection.
    /// </summary>
    public interface INetworkConnection : IDisposable
    {

        #region Properties

        /// <summary>
        /// The <see cref="ConnectionState"/> of this <see cref="INetworkConnection"/>.
        /// </summary>
        ConnectionState State { get; }
        /// <summary>
        /// The connection information for this <see cref="INetworkConnection"/> instance.
        /// </summary>
        NetworkConnectionInformation ConnectionInformation { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Opens a connection with the specified <see cref="NetworkConnectionInformation"/>.
        /// </summary>
        void Open();
        /// <summary>
        /// Closes the connection with the specified <see cref="NetworkConnectionInformation"/>.
        /// </summary>
        void Close();
        /// <summary>
        /// Tests the connection with the specified <see cref="NetworkConnectionInformation"/>.
        /// </summary>
        /// <param name="connectionSucceeded">Specifies whether or not the connection test was successful.</param>
        void Test(out bool connectionSucceeded);

        #endregion

    }
}
