using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

namespace Mauve.VisualStudio.Community.Text
{
    internal class DocumentPropertyParser : DocumentParser<IEnumerable<string>>
    {
        public DocumentPropertyParser(Document document) : base(document)
        {
        }

        public override IEnumerable<string> Parse() => throw new NotImplementedException();
    }
}
