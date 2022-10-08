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
        public void ForEachSum(IEnumerable<int> inputCollection, int expectedResult)
        {
            int sum = 0;
            inputCollection.ForEach(i => sum += i);
            Assert.AreEqual(expectedResult, sum);
        }
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 2, 0)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 3, 1)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 7, 3)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 9, -1)]
        public void IndexOf(IEnumerable<int> inputCollection, int searchValue, int expectedResult)
        {
            int index = inputCollection.IndexOf(searchValue);
            Assert.AreEqual(expectedResult, index);
        }
    }
}
