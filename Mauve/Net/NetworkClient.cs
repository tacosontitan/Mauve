using System;
using System.Net;

namespace Mauve.Net
{
    public abstract class NetworkClient<TRequest, TData> : INetworkClient<TRequest, TData> where TRequest : INetworkRequest<TData>
    {

        #region Public Methods

        public virtual INetworkResponse<TData> Execute(TRequest request)
        {
            TData response = default;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string responseMessage = string.Empty;
            try
            {
                response = ExecuteRequest(request);
                statusCode = HttpStatusCode.OK;
            } catch (Exception e)
            {
                responseMessage = e.Message;
            }

            // Return the network response.
            return new NetworkResponse<TData>
            {
                Content = response,
                StatusCode = statusCode,
                Message = responseMessage
            };
        }

        #endregion

        #region Protected Methods

        protected abstract TData ExecuteRequest(TRequest request);

        #endregion

    }
}
