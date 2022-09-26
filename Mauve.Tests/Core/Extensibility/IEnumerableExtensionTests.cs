using System;
using System.Collections.Generic;

using Mauve.Extensibility;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class IEnumerableExtensionTests
    {
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 17)]
        public void SumCollection(IEnumerable<int> inputCollection, int expectedResult)
        {
            int sum = 0;
            inputCollection.ForEach(i => sum += i);
            Assert.AreEqual(expectedResult, sum);
        }
    }
}
