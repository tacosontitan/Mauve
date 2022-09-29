using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Mauve.Extensibility;

namespace Mauve.Net
{

    public abstract class NetworkClient<TRequest, TData> :
        NetworkClient<TRequest, TData, TData> where TRequest : INetworkRequest<TData>
    {
        // This class is up for debate as we're not a big fan of a new class definition with no unique members.
    }
    public abstract class NetworkClient<TRequest, TIn, TOut> : INetworkClient<TRequest, TIn, TOut> where TRequest : INetworkRequest<TIn>
    {

        #region Public Methods

        public virtual INetworkResponse<TOut> Execute(TRequest request)
        {
            TOut response = default;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string responseMessage = string.Empty;
            try
            {
                response = ExecuteRequest(request);
                statusCode = HttpStatusCode.OK;
            } catch (Exception e)
            {
                IEnumerable<Exception> flattenedExceptionTree = e.Flatten();
                IEnumerable<string> exeptionMessages = flattenedExceptionTree.Select(exception => exception.Message);
                responseMessage = string.Join(" ", exeptionMessages);
            }

            // Return the network response.
            return new NetworkResponse<TOut>
            {
                Content = response,
                StatusCode = statusCode,
                Message = responseMessage
            };
        }

        #endregion

        #region Protected Methods

        protected abstract TOut ExecuteRequest(TRequest request);

        #endregion

    }
}
