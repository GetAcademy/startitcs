using System;

namespace FlexiArray
{
    public class GenericFlexiArray<T>
    {
        private T[] _array;
        public int Length { get; private set; }
        public int Capacity => _array.Length;

        public GenericFlexiArray()
        {
            _array = new T[10];
        }

        public void Add(int index, T value)
        {
            Length = Math.Max(Length, index + 1);
            if (index > _array.Length)
            {
                var newSize = _array.Length;
                while (index > newSize) newSize *= 2;
                var newArray = new T[newSize];
                Console.WriteLine("Øker kapasitet til " + newSize);
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
            }
            _array[index] = value;
            Console.WriteLine("Legger til  array[" + index + "]=" + value);
        }

        public T Get(int i)
        {
            return _array[i];
        }

    }
}
