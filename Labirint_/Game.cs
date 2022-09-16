using System;
using System.Collections.Generic;
using System.Text;
using static System.Console; 


namespace Labirint_
{
    class Game
    {
        private World MyWorld;
        private Player_1 CurrentPlayer;

        public void Start ( )
        {
            Title = "Добро пожаловать в лабиринт";
            CursorVisible = false;

            string[, ] grid = {

              {"▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓"},
              {"▓", " ", "▓", " ", "▓", " ", " ", " ", "▓", " ", "▓", "▓", " ", " ", "X", "▓"},
              {"▓", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", "▓", " ", " ", "▓", "▓", "▓"},
              {"▓", " ", "▓", " ", " ", " ", "▓", " ", "▓", " ", " ", " ", "▓", "▓", "▓", "▓"},
              {"▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓", "▓"},
            }; 

           MyWorld = new World(grid);

           CurrentPlayer = new Player_1(1, 2); 

           RunGameLoop();

        }

        private void DisplayIntro()
        {
            WriteLine("Добро пожаловать в лабиринт! ");
            WriteLine("\n Инструкция: ");
            WriteLine("> Используйте клавишу со стрелочками для перемещения. ");
            Write("> Попытайтесь достичь цели, которая выглядит следующим образом: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X ");
            ResetColor();
            WriteLine("> Нажмите на любую клавишу для запуска игры. ");
            ReadKey(true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("Вы выбрались! "); 
            WriteLine("Спасибо за игру! ");
            WriteLine("Нажмите на любую клавишу, чтобы закрыть игру...");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                       CurrentPlayer.X += 1; 
                    }
                    
                    break;
                default: 
                    break;
            }
        }

        private void RunGameLoop()
        {
        DisplayIntro();
            while (true)
            {
                //Draw everything.
                DrawFrame();
                //Check for player input from the keyboard and move the player.
                HandlePlayerInput();
                //Check if the player has reached the exit and end the game if so.
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }
                //TODO!
                //Give the Console a chance to render.
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}
