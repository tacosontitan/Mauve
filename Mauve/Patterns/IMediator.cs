using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMediator<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="recipient"></param>
        void Send(T data, IMediatorClient<T> recipient);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="recipients"></param>
        void Send(T data, IEnumerable<IMediatorClient<T>> recipients);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        Task SendAsync(T data, IMediatorClient<T> recipients);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        Task SendAsync(T data, IEnumerable<IMediatorClient<T>> recipients);
    }
}
