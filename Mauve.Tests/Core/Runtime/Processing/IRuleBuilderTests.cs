using System;

using Mauve.Runtime.Processing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Runtime.Processing
{
    [TestClass]
    public class IRuleBuilderTests
    {
        [TestMethod]
        [DataRow(1, 1, false, DisplayName = "Single Action")]
        [DataRow(11, 2, false, DisplayName = "Multiple Actions")]
        [DataRow(7, 3, false, DisplayName = "Chained Actions")]
        public void BasicRules(int input, int expectedActionCount, bool exceptionExpected)
        {
            int actionsExecuted = 0;
            bool exceptionOccurred = false;
            var ruleBuilder = new RuleBuilder<int>();
            Rule<int> testRule = ruleBuilder
                .When(i => i > 10).Then(i => actionsExecuted++)
                .When(i => i % 2 == 0).Then(i => actionsExecuted++)
                .WhenIn(2, 4, 6, 8).Then(i => actionsExecuted++)
                .WhenNotIn(3, 5, 9).Then(i => actionsExecuted++).Then(i => actionsExecuted++)
                .When(i => i > 15).Then(i => actionsExecuted++)
                .Unless(i => i % 6 == 0).Then(i => actionsExecuted++)
                .Build();

            try
            {
                testRule.Apply(input);
            } catch (Exception e)
            {
                exceptionOccurred = true;
                Assert.Fail(e.Message);
            }
            Assert.AreEqual(expectedActionCount, actionsExecuted);
            Assert.AreEqual(exceptionExpected, exceptionOccurred);
        }
    }
}
