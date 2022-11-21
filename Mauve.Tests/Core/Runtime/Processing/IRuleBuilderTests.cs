using System;

using Mauve.Runtime.Processing;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Runtime.Processing
{
    [TestClass]
    public class IRuleBuilderTests
    {
        [TestMethod]
        [DataRow(1, false)]
        [DataRow(10, false)]
        [DataRow(14, true)]
        public void WhenThen(int input, bool expectedResult)
        {
            bool thenInvoked = false;
            var ruleBuilder = new DynamicRuleBuilder<int>();
            DynamicRule<int> testRule = ruleBuilder
                .When(i => i > 10)
                .Then(i => thenInvoked = true)
                .Build();

            try
            {
                testRule.Apply(input);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

            Assert.AreEqual(expectedResult, thenInvoked);
        }
    }
}
