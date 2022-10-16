using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Net
{
    /// <summary>
    /// Represents a collection of different types of network credentials.
    /// </summary>
    public enum NetworkCredentialType
    {
        None = 0,
        Basic = 1,
        BearerToken = 2,
        ApiKey = 3,
        Digest = 4,
        Oauth2 = 5,
        Hawk = 6,
        Aws = 7
    }
}
