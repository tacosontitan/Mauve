using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net
{
    public class NetworkConnectionInformation
    {
        public bool UseDefaultCredentials { get; set; }
        public int? Port { get; set; }
        public string Identifier { get; set; }
        public string Focus { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}
