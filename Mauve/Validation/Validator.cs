using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mauve.Validation
{
    /// <summary>
    /// Represents an implementation of <see cref="IValidatable"/> for the purpose of performing validation.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data the validator is validating.</typeparam>
    public abstract class Validator<T> : IValidatable
    {

        #region Fields

        private readonly T _input;

        #endregion

        #region Properties

        /// <summary>
        /// A collection of <see cref="ValidationResult"/> representing the results of the validation process.
        /// </summary>
        public List<ValidationResult> Results { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Validator{T}"/> instance.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        public Validator(T input)
        {
            _input = input;
            Results = new List<ValidationResult>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Attempts to validate the input for the <see cref="Validator{T}"/> instance.
        /// </summary>
        /// <returns><see langword="true"/> if the input is valid, otherwise <see langword="false"/>.</returns>
        public bool TryValidate()
        {
            try
            {
                Validate();
                return true;
            } catch
            {
                return false;
            }
        }
        /// <summary>
        /// Validates the input for the <see cref="Validator{T}"/> instance.
        /// </summary>
        public void Validate()
        {

        }

        #endregion

        #region Protected Methods

        protected abstract void CreateRules(IValidationRuleBuilder<T> ruleBuilder);
        protected IValidationRuleBuilder<TParameter> CreateRule<TParameter>(Expression<Func<T, TParameter>> expression) => null;

        #endregion

    }
}
