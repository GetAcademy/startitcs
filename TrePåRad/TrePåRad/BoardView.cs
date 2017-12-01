using System;

namespace TrePåRad
{
    class BoardView
    {
        public static void Show(BoardModel boardModel)
        {
            Console.Clear();
            var winningSymbol = boardModel.IsWinning();
            var content = boardModel.Content;
            Console.WriteLine("  a b c");
            Console.WriteLine(" ┌─────┐");
            ShowOneLine(0, content);
            ShowOneLine(3, content);
            ShowOneLine(6, content);
            Console.WriteLine(" └─────┘");
            if (winningSymbol != CellContent.None)
            {
                var symbol = winningSymbol == CellContent.Circle ? "Datamaskinen" : "Du";
                Console.WriteLine("\n" + symbol + " har vunnet!");
                Environment.Exit(0);
            };

        }

        private static void ShowOneLine(int startIndex, CellContent[] content)
        {
            var lineNo = 1 + startIndex / 3;
            Console.Write(lineNo + "│");
            for (var i = startIndex; i < startIndex + 3; i++)
            {
                if (i > startIndex) Console.Write(' ');
                //if(content[i]==CellContent.None)
                //    Console.Write(" ");
                //else if (content[i] == CellContent.Cross)
                //    Console.Write("×");
                //else
                //    Console.Write("o");

                //char c;
                //if (content[i] == CellContent.None)
                //    c = ' ';
                //else if (content[i] == CellContent.Cross)
                //    c = '×';
                //else
                //    c = 'o';

                var isBlank = content[i] == CellContent.None;
                var isCross = content[i] == CellContent.Cross;
                Console.Write(isBlank ? ' ' : isCross ? '×' : 'o');
            }
            Console.WriteLine("│");
        }
    }
}
