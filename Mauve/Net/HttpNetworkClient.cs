using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Mauve.Extensibility;

using Mauve.Serialization;

namespace Mauve.Net
{
    public class HttpNetworkClient : INetworkClient
    {

        #region Fields

        private readonly string _baseUri;

        #endregion

        #region Constructor

        public HttpNetworkClient() { }
        public HttpNetworkClient(string baseUri) =>
            _baseUri = baseUri;

        #endregion

        #region Public Methods

        public void Send(INetworkRequest request)
        {
            HttpRequestMessage httpRequest = BuildRequestMessage(request);
            using (var client = new HttpClient())
            using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                _ = response.EnsureSuccessStatusCode();
        }
        public T Send<T>(INetworkRequest request)
        {
            HttpRequestMessage httpRequest = BuildRequestMessage(request);
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                {
                    _ = response.EnsureSuccessStatusCode();
                    string body = response.Content.ReadAsStringAsync().Result;
                    return body.Deserialize<T>(SerializationMethod.Json);
                }
            }
        }
        public void Send<T>(INetworkRequest<T> request)
        {
            HttpRequestMessage httpRequest = BuildRequestMessage(request);
            using (var client = new HttpClient())
            using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                _ = response.EnsureSuccessStatusCode();
        }
        public TOut Send<TIn, TOut>(INetworkRequest<TIn> request)
        {
            HttpRequestMessage httpRequest = BuildRequestMessage(request);
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response = client.SendAsync(httpRequest).Result)
                {
                    _ = response.EnsureSuccessStatusCode();
                    string body = response.Content.ReadAsStringAsync().Result;
                    return body.Deserialize<TOut>(SerializationMethod.Json);
                }
            }
        }
        public async Task SendAsync(INetworkRequest request, CancellationToken cancellationToken) =>
            await Task.Run(() => Send(request), cancellationToken);
        public async Task<T> SendAsync<T>(INetworkRequest request, CancellationToken cancellationToken) =>
            await Task.Run(() => Send<T>(request), cancellationToken);
        public async Task SendAsync<T>(INetworkRequest<T> request, CancellationToken cancellationToken) =>
            await Task.Run(() => Send<T>(request), cancellationToken);
        public async Task<TOut> SendAsync<TIn, TOut>(INetworkRequest<TIn> request, CancellationToken cancellationToken) =>
            await Task.Run(() => Send<TIn, TOut>(request), cancellationToken);

        #endregion

        #region Private Methods

        private HttpRequestMessage BuildRequestMessage(INetworkRequest request) =>
            BuildRequestMessage(
                request.Uri,
                request.Method,
                request.Headers,
                request.Parameters,
                null);
        private HttpRequestMessage BuildRequestMessage<T>(INetworkRequest<T> request) =>
            BuildRequestMessage(
                request.Uri,
                request.Method,
                request.Headers,
                request.Parameters,
                request.Data);
        private HttpRequestMessage BuildRequestMessage(
            string uri,
            HttpMethod method,
            Dictionary<string, object> headers,
            Dictionary<string, object> parameters,
            object body)
        {
            string queryParams = string.Empty;
            if (parameters?.Count > 0)
                foreach (KeyValuePair<string, object> parameter in parameters)
                    queryParams += $"{parameter.Key}={parameter.Value}&";

            queryParams = queryParams.TrimEnd('&');
            var combinedUri = new Uri(new Uri(_baseUri), uri);
            var newUri = new Uri(combinedUri, string.IsNullOrWhiteSpace(queryParams) ? string.Empty : $"?{queryParams}");
            var httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = newUri
            };

            foreach (KeyValuePair<string, object> header in headers)
                httpRequest.Headers.Add(header.Key, header.Value.ToString());

            if (!(body is null))
                httpRequest.Content = new StringContent(body.Serialize(SerializationMethod.Json));

            return httpRequest;
        }

        #endregion

    }
}
