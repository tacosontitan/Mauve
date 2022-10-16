using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net
{
    internal class HttpNetworkRequest<T> : INetworkRequest<T>
    {
        public T Data { get; set; }
        public Dictionary<string, object> Headers { get; set; }
        public NetworkRequestMethod Method { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}
