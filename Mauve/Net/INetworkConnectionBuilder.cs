namespace Mauve.Net
{
    public interface INetworkConnectionBuilder
    {
        INetworkConnection Create(NetworkConnectionInformation connectionInformation);
    }
}
