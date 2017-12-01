namespace Yatzy
{
    public class Dice
    {
        public int Number { get; private set; }

        public Dice() : this(6)
        {            
        }

        public Dice(int number)
        {
            Number = number;
        }

        public void Roll()
        {
            Number = YatzyRandom.Instance.GetNumber();
        }
    }
}
