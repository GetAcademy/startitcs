using System.Linq;

namespace Yatzy
{
    public class DiceSet
    {
        private readonly Dice[] _dice;

        public DiceSet()
        {
            _dice = new[] { new Dice(), new Dice(), new Dice(), new Dice(), new Dice() };
        }

        public DiceSet(int v1, int v2, int v3, int v4, int v5)
        {
            _dice = new[] { new Dice(v1), new Dice(v2), new Dice(v3), new Dice(v4), new Dice(v5) };
        }

        public int[] GetValues()
        {
            return _dice.Select(d => d.Number).ToArray();
        }

        public int GetPointsAsOnePair()
        {
            var counts = GetCounts();
            for (var diceValue = counts.Length - 1; diceValue > 0; diceValue--)
            {
                if (counts[diceValue] > 1)
                {
                    return diceValue * 2;
                }
            }
            return 0;
        }

        public int[] GetCounts()
        {
            var counts = new int[7];
            foreach (var t in _dice)
            {
                counts[t.Number]++;
            }
            return counts;
        }
    }
}
