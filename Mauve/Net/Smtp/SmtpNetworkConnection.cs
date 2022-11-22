using System.Data;
using System.Net;

namespace Mauve.Net.Smtp
{
    public class SmtpNetworkConnection : INetworkConnection
    {

        #region Properties

        public ConnectionState State { get; private set; }
        public NetworkConnectionInformation ConnectionInformation { get; }

        #endregion

        #region Constructor

        public SmtpNetworkConnection(NetworkConnectionInformation connectionInformation) =>
            ConnectionInformation = connectionInformation;

        #endregion

        #region Public Methods

        public void Close() => State = ConnectionState.Closed;
        public void Dispose() => Close();
        public void Open()
        {
            State = ConnectionState.Connecting;
            Test(out bool connectionSucceeded);
            State = connectionSucceeded
                ? ConnectionState.Open
                : ConnectionState.Closed;
        }
        public void Test(out bool connectionSucceeded)
        {
            var request = (HttpWebRequest)WebRequest.Create(ConnectionInformation.Uri);
            request.Timeout = 3000;
            request.Method = "HEAD";
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                    connectionSucceeded = response.StatusCode == HttpStatusCode.OK;
            } catch (WebException)
            {
                connectionSucceeded = false;
            }
        }

        #endregion

    }
}
