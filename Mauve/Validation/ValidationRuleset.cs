using System.Collections.Generic;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents a collection of <see cref="ValidationRule"/> instances to be applied during validation.
    /// </summary>
    public class ValidationRuleset
    {

        #region Fields

        private readonly List<ValidationRule> _rules;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="ValidationRuleset"/> instance.
        /// </summary>
        public ValidationRuleset() =>
            _rules = new List<ValidationRule>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new <see cref="ValidationRule"/> to the <see cref="ValidationRuleset"/>.
        /// </summary>
        /// <param name="rule">The <see cref="ValidationRule"/> to add to the ruleset.</param>
        public void Add(ValidationRule rule) =>
            _rules.Add(rule);
        /// <summary>
        /// Applies all of the <see cref="ValidationRule"/> instances within the ruleset.
        /// </summary>
        public void Apply() =>
            _rules.ForEach(rule => rule.Apply());

        #endregion

    }
}
