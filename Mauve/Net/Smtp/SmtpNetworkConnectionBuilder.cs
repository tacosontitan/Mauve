namespace Mauve.Net.Smtp
{
    public class SmtpNetworkConnectionBuilder : INetworkConnectionBuilder
    {

        #region Public Methods

        public INetworkConnection Create(NetworkConnectionInformation connectionInformation)
        {
            INetworkConnection connection = new SmtpNetworkConnection(connectionInformation);
            connection.Open();
            return connection;
        }

        #endregion

    }
}
