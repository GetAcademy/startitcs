using System;

namespace FlexiArray
{
    class FlexiArray
    {
        private int[] _array;
        public int Length { get; private set; }
        public int Capacity => _array.Length;
        //public int Capacity
        //{
        //    get { return _array.Length; }
        //}

        public FlexiArray()
        {
            _array = new int[10];
        }

        public void Add(int index, int value)
        {
            Length = Math.Max(Length, index + 1);
            if (index > _array.Length)
            {
                var newSize = _array.Length;
                while (index > newSize) newSize *= 2;
                var newArray = new int[newSize];
                Console.WriteLine("Øker kapasitet til " + newSize);
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
            }
            _array[index] = value;
            Console.WriteLine("Legger til array[" + index + "]=" + value);
        }

        public int Get(int i)
        {
            return _array[i];
        }
    }
}
