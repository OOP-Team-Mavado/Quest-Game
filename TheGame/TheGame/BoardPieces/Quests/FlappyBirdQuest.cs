using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheGame.BoardInterfaces;
using TheGame.BoardPieces.Quests.FlappyBirdGame;
using TheGame.Utils;

namespace TheGame.BoardPieces.Quests
{
    namespace FlappyBirdGame
    {
        abstract class GameElement
        {
            public abstract void UpdateNextFrame();

            public int Row { get; set; }
            public int Column { get; set; }

            public abstract char DisplaySymbol { get; }
            public abstract ConsoleColor DisplayColor { get; }
        }

        class EmptySpaceElement : GameElement
        {
            public override ConsoleColor DisplayColor
            {
                get
                {
                    return ConsoleColor.White;
                }
            }

            public override char DisplaySymbol
            {
                get
                {
                    return ' ';
                }
            }

            public override void UpdateNextFrame()
            {
                this.Column--;
            }
        }

        class PlayerElement : GameElement
        {
            private bool isJumping = false;
            private int remainingJumpFrames = 0;
            

            public override ConsoleColor DisplayColor
            {
                get
                {
                    return ConsoleColor.Red;
                }
            }

            public override char DisplaySymbol
            {
                get
                {
                    return 'w';
                }
            }

            public override void UpdateNextFrame()
            {
                if(isJumping && remainingJumpFrames > 0)
                {
                    this.remainingJumpFrames--;
                    this.Row--;
                }
                else if(isJumping && remainingJumpFrames == 0)
                {
                    this.isJumping = false;
                }
                else
                {
                    this.Row++;
                }
            }

            public void Jump()
            {
                this.isJumping = true;
                this.remainingJumpFrames = 3;
            }

            public bool IsColliding(ObstacleElement obstacle)
            {
                if (obstacle.Row == this.Row && obstacle.Column == this.Column)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class ObstacleElement : GameElement
        {
            public override ConsoleColor DisplayColor
            {
                get
                {
                    return ConsoleColor.Magenta;
                }
            }

            public override char DisplaySymbol
            {
                get
                {
                    return '@';
                }
            }

            public override void UpdateNextFrame()
            {
                this.Column--;
            }
        }

    }

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
                //Console.ForegroundColor = ConsoleColor.Cyan;

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
