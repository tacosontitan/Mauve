using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Security
{
    public class Signed<TData, TSignatureAuthority>
    {

        #region Properties

        public TData Data { get; set; }
        public Signature<TSignatureAuthority> Signature { get; set; }

        #endregion

    }
}
