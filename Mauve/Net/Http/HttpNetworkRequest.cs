using System;
using System.Collections.Generic;
using System.IO;

namespace Mauve.Net
{
    internal class HttpNetworkRequest : INetworkRequest<Stream>
    {
        public Stream Data { get; set; }
        public Dictionary<string, object> Headers { get; set; }
        public NetworkRequestMethod Method { get; set; }
        public NetworkCredential Credentials { get; set; }
        public int? Port { get; set; }
        public Uri Uri { get; set; }
    }
}
