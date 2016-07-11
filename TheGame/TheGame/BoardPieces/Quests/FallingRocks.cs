namespace TheGame.BoardPieces.Quests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class FallingRocks : AbstractQuest, IGame, IInteractable
    {
        private Position position;

        public FallingRocks(Position position)
            : base(position)
        {
            this.position = position;
            this.DisplaySymbol = "R";
        }

        public override double StartGame()
        {
            int rockCount = 0;
            int sleepTime = 0;
            int score = 0;

            string label;

            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            while (true)
            {
                Console.Clear();
                while (sleepTime == 0)
                {
                    label = "Please choose difficulty:";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), (Console.WindowHeight - 2) / 2);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(label);

                    label = "Press 1 for easy.";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), ((Console.WindowHeight - 2) / 2) + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(label);

                    label = "Press 2 for medium.";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), ((Console.WindowHeight - 2) / 2) + 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(label);

                    label = "Press 3 for hard.";
                    Console.SetCursorPosition((Console.WindowWidth / 2) - (label.Length / 2), ((Console.WindowHeight - 2) / 2) + 3);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(label);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo menuChoise = Console.ReadKey();
                        if (menuChoise.Key == ConsoleKey.D1)
                        {
                            rockCount = 40;
                            sleepTime = 10;
                        }
                        else if (menuChoise.Key == ConsoleKey.D2)
                        {
                            rockCount = 50;
                            sleepTime = 7;
                        }
                        else if (menuChoise.Key == ConsoleKey.D3)
                        {
                            rockCount = 60;
                            sleepTime = 5;
                        }
                    }
                }

                Console.Clear();
                score = Game(rockCount, sleepTime);
                while (true)
                {
                    Console.Clear();
                    label = "GAME OVER";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(label);

                    switch (sleepTime)
                    {
                        case 10:
                            label = "Your score is " + score + " on Easy difficulty";
                            score += 1;
                            break;

                        case 7:
                            label = "Your score is " + score + " on Medium difficulty";
                            score += 3;
                            break;

                        case 5:
                            label = "Your score is " + score + " on Hard difficulty";
                            score += 5;
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine(label);
                    Console.WriteLine();
                    Console.WriteLine(Constants.ContinueMessage);
                    Console.ReadLine();
                    return score;
                }
            }
        }

        private static int Game(int rockCount, int sleepTime)
        {
            char[] rockSymbols = new char[10] { '#', '+', '&', '!', '=', '$', '~', '^', '?', '%' }; // symbols for the rocks, can be changed
            sbyte rocksSpeed = 1;
            double score = 0;
            int finalScore = 0;
            Stone[] rocks = new Stone[rockCount];

            Stone dwarf = new Stone();
            dwarf.X = Console.WindowWidth / 2;
            dwarf.Y = Console.WindowHeight - 1;

            for (int i = 0; i < rockCount; i++)
            {
                rocks[i].X = Generator.GetRandomNumber(1, Console.WindowWidth - 1);
                rocks[i].Y = Generator.GetRandomNumber(1, Console.WindowHeight - 5);
                rocks[i].Color = (ConsoleColor)Generator.GetRandomNumber(10, 14);
                rocks[i].Symbol = rockSymbols[Generator.GetRandomNumber(1, rockSymbols.Length)];
            }

            while (true)
            {
                if (rocksSpeed % 23 == 0)
                {
                    for (int i = 0; i < rockCount; i++)
                    {
                        if (rocks[i].Y == (Console.WindowHeight - 1))
                        {
                            Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                            Console.Write(" ");
                            rocks[i].X = Generator.GetRandomNumber(1, Console.WindowWidth - 1);
                            rocks[i].Y = Generator.GetRandomNumber(0, 3);
                            rocks[i].Color = (ConsoleColor)Generator.GetRandomNumber(10, 14);
                            rocks[i].Symbol = rockSymbols[Generator.GetRandomNumber(1, rockSymbols.Length)];
                        }
                        else
                        {
                            Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                            Console.Write(" ");
                            rocks[i].Y++;
                        }

                        Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                        Console.ForegroundColor = rocks[i].Color;
                        Console.Write(rocks[i].Symbol);
                    }
                }

                if (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                    Console.Write("   ");
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        dwarf.X++;
                    }
                    else if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        dwarf.X--;
                    }
                }

                if ((dwarf.X == Console.WindowWidth - 2) || (dwarf.X < 1))
                {
                    return finalScore * 10;
                }

                for (int i = 0; i < rockCount; i++)
                {
                    if (((dwarf.X == rocks[i].X) && (dwarf.Y == rocks[i].Y)) ||
                        ((dwarf.X == rocks[i].X - 1) && (dwarf.Y == rocks[i].Y)) ||
                        ((dwarf.X == rocks[i].X + 1) && (dwarf.Y == rocks[i].Y)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                        Console.Write("\\@/");
                        return finalScore * 10;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                Console.Write("\\☺/");

                Thread.Sleep(sleepTime);
                rocksSpeed++;
                score += 0.02;
                finalScore = (int)score;
            }
        }

        private struct Stone
        {
            public int X, Y;
            public char Symbol;
            public ConsoleColor Color;

            public Stone(int x, int y, char symbol, ConsoleColor color)
            {
                this.X = x;
                this.Y = y;
                this.Symbol = symbol;
                this.Color = color;
            }
        }
    }
}