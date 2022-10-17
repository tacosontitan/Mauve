using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net
{
    internal class HttpNetworkRequest : INetworkRequest<Stream>
    {
        public Stream Data { get; set; }
        public Dictionary<string, object> Headers { get; set; }
        public NetworkRequestMethod Method { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}
