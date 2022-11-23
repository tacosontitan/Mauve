using System;
using System.Threading.Tasks;

namespace Mauve.Patterns.Behavioral
{
    internal class Mediator : IMediator
    {

        #region Fields

        #endregion

        #region Constructor

        #endregion
        public T Send<T>(IMediatorRequest<T> request) => throw new NotImplementedException();
        public Task<T> SendAsync<T>(IMediatorRequest<T> request) => throw new NotImplementedException();
    }
}
