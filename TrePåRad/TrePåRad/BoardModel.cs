using System;
using System.Collections.Generic;
using System.Linq;

namespace TrePåRad
{
    class BoardModel
    {
        public bool IsGameStopped { get; private set; }
        public CellContent[] Content { get; private set; }
        private readonly Random _random = new Random();
        private Combination[] _winningCombinations;

        public BoardModel()
        {
            Content = new CellContent[9];
            _winningCombinations = new[]
            {
                new Combination(Content, 0, 1, 2),
                new Combination(Content, 3, 4, 5),
                new Combination(Content, 6, 7, 8),
                new Combination(Content, 0, 3, 6),
                new Combination(Content, 1, 4, 7),
                new Combination(Content, 2, 5, 8),
                new Combination(Content, 0, 4, 8),
                new Combination(Content, 2, 4, 6),
            };
        }

        public CellContent IsWinning()
        {
            return _winningCombinations.Select(c => c.IsWinning()).FirstOrDefault(x => x != CellContent.None);
        }

        public void SetCross(string positionStr)
        {
            var col = positionStr[0] == 'a' ? 0 : positionStr[0] == 'b' ? 1 : 2;
            var row = Convert.ToInt32(positionStr[1].ToString()) - 1;
            var position = row * 3 + col;
            Content[position] = CellContent.Cross;
        }

        public void SetRandomCircle()
        {
            var randomIndex = _random.Next(0, 8);
            while (Content[randomIndex] != CellContent.None)
            {
                randomIndex = _random.Next(0, 8);
            }
            Content[randomIndex] = CellContent.Circle;
        }
    }
}