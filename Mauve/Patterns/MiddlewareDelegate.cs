using System.Threading.Tasks;

namespace Mauve.Patterns
{
    public delegate Task MiddlewareDelegate();
    public delegate Task MiddlewareDelegate<T>(T input);
    public delegate Task MiddlewareDelegate<T1, T2>(T1 t1, T2 t2);
    public delegate Task MiddlewareDelegate<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4);
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">The first type the delegate works with.</typeparam>
    /// <typeparam name="T2">The second type the delegate works with.</typeparam>
    /// <typeparam name="T3">The third type the delegate works with.</typeparam>
    /// <typeparam name="T4">The fourth type the delegate works with.</typeparam>
    /// <typeparam name="T5">The fifth type the delegate works with.</typeparam>
    /// <typeparam name="T6">The sixth type the delegate works with.</typeparam>
    /// <typeparam name="T7">The seventh type the delegate works with.</typeparam>
    /// <typeparam name="T8">The eighth type the delegate works with.</typeparam>
    /// <typeparam name="T9">The ninth type the delegate works with.</typeparam>
    /// <param name="t1">The first parameter for the delegate.</param>
    /// <param name="t2">The second parameter for the delegate.</param>
    /// <param name="t3">The third parameter for the delegate.</param>
    /// <param name="t4">The fourth parameter for the delegate.</param>
    /// <param name="t5">The fifth parameter for the delegate.</param>
    /// <param name="t6">The sixth parameter for the delegate.</param>
    /// <param name="t7">The seventh parameter for the delegate.</param>
    /// <param name="t8">The eighth parameter for the delegate.</param>
    /// <param name="t9">The ninth parameter for the delegate.</param>
    /// <returns></returns>
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
}
