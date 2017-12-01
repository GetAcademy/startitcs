using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yatzy;

namespace YatzyTest
{
    [TestClass]
    public class DiceSetTest
    {
        [TestMethod]
        public void TestGetValues()
        {
            var diceSet = new DiceSet();
            var values = diceSet.GetValues();
            Assert.AreEqual(5, values.Length);
        }

        [TestMethod]
        public void TestPointsAsOnePair()
        {
            var diceSet = new DiceSet(3, 3, 1, 2, 5);
            var points = diceSet.GetPointsAsOnePair();
            Assert.AreEqual(6, points);
        }

        [TestMethod]
        public void TestPointsAsOnePair2()
        {
            var diceSet = new DiceSet(6, 3, 1, 2, 5);
            var points = diceSet.GetPointsAsOnePair();
            Assert.AreEqual(0, points);
        }

        [TestMethod]
        public void TestGetCounts()
        {
            var diceSet = new DiceSet(3, 3, 1, 2, 5);
            var counts = diceSet.GetCounts();
            var expectedCounts = new[] {0, 1, 1, 2, 0, 1, 0};
            CollectionAssert.AreEqual(expectedCounts, counts);
        }
    }
}
