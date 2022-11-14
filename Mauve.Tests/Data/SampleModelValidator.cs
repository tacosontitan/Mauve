using System;

using Mauve.Validation;

namespace Mauve.Tests.Data
{
    internal class SampleModelValidator : Validator<SampleModel>
    {
        public SampleModelValidator(SampleModel input) : base(input)
        {
        }
        protected override void CreateRules()
        {
            _ = CreateRule(model => model.Timestamp)
                .WhenNull().Throw(new ArgumentNullException("Timestamp is null."))
                .WhenIn(DateTime.MinValue, DateTime.MaxValue).Throw(new ArgumentException("Timestamp is invalid."))
                .When(timestamp => timestamp > DateTime.Now).Throw(new ArgumentException("Timestamp cannot be in the future."))
                .WhenEqualTo(DateTime.Now).Throw(new ArgumentException("Timestamp is now."))
                .WhenNotEqualTo(new DateTime(2020, 1, 1))
                .Then(timestamp => Console.WriteLine(timestamp));
        }
    }
}
