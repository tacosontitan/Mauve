using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauve.Security
{
    internal class CaesarCryptographyProvider : CryptographyProvider
    {
        public override T Decrypt<T>(string input) => throw new NotImplementedException();
        public override void Dispose() => throw new NotImplementedException();
        public override string Encrypt<T>(T input) => throw new NotImplementedException();
    }
}
