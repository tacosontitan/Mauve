namespace Mauve.Runtime.Processing
{
    public class Rule<T>
    {

        #region Fields

        private readonly RuleHandler<T> _ruleHandler;

        #endregion

        #region Constructor

        public Rule(RuleHandler<T> handler) =>
            _ruleHandler = handler;

        #endregion

        #region Public Methods

        public void Apply(T input) =>
            _ruleHandler.Execute(input);

        #endregion

    }
}
