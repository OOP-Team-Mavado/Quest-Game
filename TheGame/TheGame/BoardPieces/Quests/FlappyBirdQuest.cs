using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheGame.BoardInterfaces;
using TheGame.Utils;
using TheGame.BoardPieces.Quests.FlappyClasses;

namespace TheGame.BoardPieces.Quests
{

    class FlappyBirdQuest : AbstractQuest, IGame, IInteractable
    {

        List<GameElement> gameElements = new List<GameElement>();
        PlayerElement player;
        private int score = 0;

        public FlappyBirdQuest(Position position) : base(position)
        {
            this.DisplaySymbol = "F";
        }

        public override double StartGame()
        {

            GenerateGameScene();
            Console.SetWindowSize(51, 18);
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();

                foreach (var element in gameElements)
                {
                    element.UpdateNextFrame();

                    if (element.Column < 0 || element.Column >= 50 ||
                        element.Row < 0 || element.Row >= 16 ||
                        element is EmptySpaceElement)
                    {
                        continue;
                    }

                    ObstacleElement obstacle = element as ObstacleElement;
                    if (obstacle != null)
                    {
                        if (player.IsColliding(obstacle))
                        {
                            gameOver = true;
                        }
                    }


                    Console.SetCursorPosition(element.Column, element.Row);
                    Console.ForegroundColor = element.DisplayColor;
                    Console.Write(element.DisplaySymbol);
                }
                Console.SetCursorPosition(0, 16);
                Console.Write("Score: {0}", score);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (pressedKey.Key == ConsoleKey.Spacebar)
                    {
                        this.player.Jump();
                    }
                }
                score++;
                Thread.Sleep(100);
            }

            this.PrintVictoryScreen();
            Console.ReadKey();
            Console.SetWindowSize(80, 44);
            return score;
        }

        private void PrintVictoryScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(10, 7);
            Console.Write("###############################");
            Console.SetCursorPosition(10, 8);
            Console.Write("#          Game Over          #");
            Console.SetCursorPosition(10, 9);
            Console.Write("#        Score: {0,5}         #", score);
            Console.SetCursorPosition(10, 10);
            Console.Write("#  Press any key to continue  #");
            Console.SetCursorPosition(10, 11);
            Console.Write("###############################");
        }

        private void GenerateGameScene()
        {
            string text = File.ReadAllText("FlappyMap.txt");
            string[] mapText = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < mapText.Length; i++)
            {
                for (int j = 0; j < mapText[i].Length; j++)
                {
                    GameElement element;
                    if (mapText[i][j] == 'w')
                    {
                        this.player = new PlayerElement();
                        element = this.player;
                    }
                    else if (mapText[i][j] == '@')
                    {
                        element = new ObstacleElement();
                    }
                    else
                    {
                        element = new EmptySpaceElement();
                    }
                    
                    element.Row = i;
                    element.Column = j;
                    gameElements.Add(element);
                }
            }

        }
    }
}
