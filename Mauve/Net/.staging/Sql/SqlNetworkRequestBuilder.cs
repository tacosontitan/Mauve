using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mauve.Patterns;

namespace Mauve.Net.Sql
{
    public abstract class SqlNetworkRequestBuilder : IBuilder<SqlNetworkRequest>
    {

        #region Public Methods

        public abstract SqlNetworkRequestBuilder AddParameter<T>(string name, T value);
        public abstract SqlNetworkRequest Build();

        #endregion

    }
}
