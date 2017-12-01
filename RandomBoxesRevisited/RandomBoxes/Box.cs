using System;

namespace RandomBoxes
{
    public class Box
    {
        //public int directionX { get; private set; }
        //public int directionY { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private int _minimumSize = 3;

        public Box(Random random, int maxX, int maxY)
        {
            //directionX = random.Next(0, 2);
            //directionY = random.Next(0, 2);
            X = random.Next(0, maxX - _minimumSize);
            Y = random.Next(1, maxY - _minimumSize); ;
            Width = random.Next(_minimumSize, maxX - X); ;
            Height = random.Next(_minimumSize, maxY - Y);
        }

        public Box(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        //public void Move()
        //{
        //    X += directionX;
        //    Y += directionY;
        //}
        public int GetTopRowY()
        {
            return Y;
        }

        public int GetBottomRowY()
        {
            return Y + Height;
        }
    }
}
