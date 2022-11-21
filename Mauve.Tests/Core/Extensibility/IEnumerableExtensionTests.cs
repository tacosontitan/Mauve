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
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 2, 3)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 3, 5)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 5, 7)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 7, -1)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 9, -1)]
        [DataRow(null, 9, 0)]
        public void Next(IEnumerable<int> inputCollection, int searchValue, int expectedResult)
        {
            int result = -1;
            try
            {
                result = inputCollection.Next(searchValue);
            } catch { /* Gracefully ignore. */ }

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 2, 3)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 3, 5)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 5, 7)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 7, 0)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 9, 0)]
        [DataRow(null, 9, 0)]
        public void NextOrDefault(IEnumerable<int> inputCollection, int searchValue, int expectedResult)
        {
            int result = -1;
            try
            {
                result = inputCollection.NextOrDefault(searchValue);
            } catch { /* Gracefully ignore. */ }

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 2, -1)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 3, 2)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 5, 3)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 7, 5)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 9, -1)]
        [DataRow(null, 9, 0)]
        public void Previous(IEnumerable<int> inputCollection, int searchValue, int expectedResult)
        {
            int result = -1;
            try
            {
                result = inputCollection.Previous(searchValue);
            } catch { /* Gracefully ignore. */ }

            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        [DataRow(new int[] { 2, 3, 5, 7 }, 2, 0)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 3, 2)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 5, 3)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 7, 5)]
        [DataRow(new int[] { 2, 3, 5, 7 }, 9, 0)]
        [DataRow(null, 9, 0)]
        public void PreviousOrDefault(IEnumerable<int> inputCollection, int searchValue, int expectedResult)
        {
            int result = -1;
            try
            {
                result = inputCollection.PreviousOrDefault(searchValue);
            } catch { /* Gracefully ignore. */ }

            Assert.AreEqual(expectedResult, result);
        }
    }
}
