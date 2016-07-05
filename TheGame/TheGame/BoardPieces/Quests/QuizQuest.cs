namespace TheGame.BoardPieces.Quests
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class QuizQuest : IDisplayPiece, IGame, IInteractable
    {
        private List<Position> positions;
        private int id;
        private string displaySymbol = Constants.QuestDisplaySymbol;
        private ConsoleColor displayColor = ConsoleColor.DarkGreen;

        public QuizQuest(List<Position> initialPositions)
        {
            this.positions = initialPositions;
        }

        public List<Position> GetPositions()
        {
            return this.positions;
        }

        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public string GetDisplaySymbol()
        {
            return this.displaySymbol;
        }

        public ConsoleColor GetColor()
        {
            return this.displayColor;
        }

        public int StartGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("When did Bulgaria join the EU?");
            string playerAnswer = Console.ReadLine();
            int result = 0;

            if (playerAnswer == "2007")
            {
                Console.WriteLine("Correct!");
                result = 1;
            }
            else
            {
                Console.WriteLine("Wrong.");
                result = -1;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return result;
        }

        public int GetInteractionResult()
        {
            return this.StartGame();
        }
    }
}