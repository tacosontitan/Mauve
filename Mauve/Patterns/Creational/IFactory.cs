using System;

namespace Mauve.Patterns.Creational
{
    internal interface IFactory
    {
        T Create<T>();
        T Create<T>(Type specificType);
    }
}
