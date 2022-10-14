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
    public delegate Task MiddlewareDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
}
