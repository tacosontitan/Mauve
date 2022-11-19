using System.Collections.Generic;

namespace Mauve.Runtime.Processing
{
    public class Rule<T>
    {

        #region Sub-Types

        private class Instruction
        {

        }

        #endregion

        #region Fields

        private readonly List<Instruction> _instructions;

        #endregion

        #region Constructor

        public Rule() =>
            _instructions = new List<Instruction>();

        #endregion

        #region Public Methods

        #endregion

        #region Internal Methods

        #endregion

    }
}
