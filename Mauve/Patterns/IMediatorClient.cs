using System.Threading.Tasks;

namespace Mauve.Patterns
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMediatorClient<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void HandleIncomingData(T data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task HandleIncomingDataAsync(T data);
    }
}
