using System;
using System.Collections.Generic;

namespace Mauve.Runtime.Processing
{
    internal class Instruction<T>
    {
        public InstructionType Type { get; set; }
        public Instruction<T> Previous { get; set; }
        public Instruction<T> Next { get; set; }
        public List<Predicate<T>> Conditions { get; set; }
        public List<Action<T>> Actions { get; set; }
    }
}
