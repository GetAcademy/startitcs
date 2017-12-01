using System;

namespace RandomBoxes
{
    public class Screen
    {
        private ScreenRow[] _rows;

        public Screen(int width, int height)
        {
            _rows = new ScreenRow[height];
            for (var i = 0; i < _rows.Length; i++)
            {
                _rows[i] = new ScreenRow(width);
            }
        }

        public void Add(Box box)
        {
            var firstY = box.GetTopRowY();
            var lastY = box.GetBottomRowY();
            _rows[firstY].AddTopRow(box.X, box.Width);
            _rows[lastY].AddBottomRow(box.X, box.Width);
            for (var rowId = firstY + 1; rowId < lastY; rowId++)
            {
                _rows[rowId].AddMiddleRow(box.X, box.Width);
            }
        }

        public void Show()
        {
            Console.Clear();
            foreach (var row in _rows)
            {
                row.Show();
            }
        }
    }
}
