using Yatzy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YatzyTest
{
    [TestClass]
    public class DiceTest
    {
        [TestMethod]
        public void TestRoll()
        {
            var dice = new Dice();
            dice.Roll();
            Assert.AreNotEqual(0, dice.Number);
        }
    }
}
