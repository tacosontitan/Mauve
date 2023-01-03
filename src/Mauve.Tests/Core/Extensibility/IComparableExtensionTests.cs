using System;

using Mauve.Extensibility;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mauve.Tests.Core.Extensibility
{
    [TestClass]
    public class IComparableExtensionTests
    {

        #region Public Methods

        [TestMethod()]
        [DataRow(3, 0, 1, false)]
        [DataRow(3, 5, 9, false)]
        [DataRow(3, 0, 5, true)]
        [DataRow(3, 5, 1, false)]
        public void WithinRange(IComparable input, IComparable lowerBound, IComparable upperBound, bool expectedResult)
        {
            try
            {
                bool withinRange = input.WithinRange(lowerBound, upperBound);
                Assert.AreEqual(expectedResult, withinRange);
            } catch (Exception e)
            {
                // An exception is thrown if the bounds are out of order.
                bool offBalance = lowerBound.CompareTo(upperBound) > 0 ||
                                  upperBound.CompareTo(lowerBound) < 0;

                // If we're not off balance, then something else happened.
                if (!offBalance)
                    Assert.Fail(e.Message);
            }
        }
        [TestMethod()]
        [DataRow(3, 0, 1, 1)]
        [DataRow(3, 5, 9, 5)]
        [DataRow(3, 0, 5, 3)]
        [DataRow(3, 5, 1, 3)]
        public void Constrain(IComparable input, IComparable lowerBound, IComparable upperBound, IComparable expectedResult)
        {
            try
            {
                IComparable constrainedValue = input.Constrain(lowerBound, upperBound);
                Assert.AreEqual(expectedResult, constrainedValue);
            } catch (Exception e)
            {
                // An exception is thrown if the bounds are out of order.
                bool offBalance = lowerBound.CompareTo(upperBound) > 0 ||
                                  upperBound.CompareTo(lowerBound) < 0;

                // If we're not off balance, then something else happened.
                if (!offBalance)
                    Assert.Fail(e.Message);
            }
        }

        #endregion

    }
}
