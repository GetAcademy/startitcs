namespace BottleExerciseSolver
{
    class Bottle
    {
        public int Capacity { get; }
        public int Content { get; private set; }

        public Bottle(int capacity)
        {
            Capacity = capacity;
        }

        public bool Fill(int volume)
        {
            if (volume + Content > Capacity) return false;
            Content += volume;
            return true;
        }

        public void FillToTopFromTap()
        {
            Content = Capacity;
        }

        public bool FillToTop(Bottle otherBottle)
        {
            var volumeNeeded = Capacity - Content;
            if (otherBottle.Content < volumeNeeded) return false;
            Content = Capacity;
            otherBottle.Remove(volumeNeeded);
            return true;
        }

        private void Remove(int volumeNeeded)
        {
            Content -= volumeNeeded;
        }

        public int Empty()
        {
            var content = Content;
            Content = 0;
            return content;
        }

        public bool IsEmpty()
        {
            return Content == 0;
        }
    }
}
