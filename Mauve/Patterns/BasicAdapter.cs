
using SystemConvert = System.Convert;

namespace Mauve.Patterns
{
    public class BasicAdapter<T1, T2> : IAdapter<T1, T2>
    {
        public T2 Convert(T1 input) =>
            (T2)SystemConvert.ChangeType(input, typeof(T2));
        public T1 Convert(T2 input) =>
            (T1)SystemConvert.ChangeType(input, typeof(T1));
    }
}
