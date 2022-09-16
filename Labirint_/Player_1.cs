using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Labirint_
{
    class Player_1
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker; 
        private ConsoleColor PlayerColor; 

        public Player_1(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = ConsoleColor.Red;
        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}
