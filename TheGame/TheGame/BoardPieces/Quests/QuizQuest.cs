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
        private Dictionary<string, string> quizes = new Dictionary<string, string>
        {
            { "When did Bulgaria join the EU?", "2007" },
            {"Porsche is a brand of car that originated in what country?", "Germany" },
            {"Who was the first human to travel into space?", "Yuri Gagarin" },
            {"The Roman numeral \"D\" stands for what number?", "500" },
            {"What is the name for the Greek goddess of victory?", "Nike" },
            {"According to Greek mythology which Gorgon had snakes for hair and could turn onlookers into stone?", "Medusa" },
            {"The Roman numeral \"L\" stands for what number?", "50" },
            {"In what year did the Titanic sink?","1912" },
            {"According to Greek mythology, who was the goddess of beauty?","Aphrodite" },
            {"Who was the first woman pilot to fly solo across the Atlantic?","Amelia Earhart" }

        };

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