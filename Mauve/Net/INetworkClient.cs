namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkClient{TRequest, TData}"/> instance capable of executing <see cref="INetworkRequest{TData}"/> instances.
    /// </summary>
    public interface INetworkClient<TRequest, TData> where TData : INetworkRequest<TData>
    {
        /// <summary>
        /// Executes the specified <see cref="TRequest"/> instance across the network this <see cref="INetworkClient{TRequest, TData}"/> operates within.
        /// </summary>
        /// <param name="request">The <see cref="TRequest"/> to execute.</param>
        /// <returns>Returns the <see cref="INetworkResponse{TData}"/> containing response information from the network this <see cref="INetworkClient{TRequest, TData}"/> operates within.</returns>
        INetworkResponse<TData> Execute(TRequest request);
    }
}
