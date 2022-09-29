namespace Mauve.Net
{
    /// <summary>
    /// Represents an <see cref="INetworkClient{TRequest, TIn, TOut}"/> instance capable of executing <see cref="INetworkRequest{TIn}"/> instances.
    /// </summary>
    public interface INetworkClient<TRequest, TIn, TOut> where TRequest : INetworkRequest<TIn>
    {
        /// <summary>
        /// Executes the specified <see cref="TRequest"/> instance across the network this <see cref="INetworkClient{TRequest, TIn, TOut}"/> operates within.
        /// </summary>
        /// <param name="request">The <see cref="TRequest"/> to execute.</param>
        /// <returns>Returns the <see cref="INetworkResponse{TOut}"/> containing response information from the network this <see cref="INetworkClient{TRequest, TIn, TOut}"/> operates within.</returns>
        INetworkResponse<TOut> Execute(TRequest request);
    }
}
