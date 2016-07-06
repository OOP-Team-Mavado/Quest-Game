namespace TheGame.BoardPieces.Quests
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class QuizQuest : AbstractQuest, IGame, IInteractable
    {
        private Position position;

        private Dictionary<int, List<string>> quizes = new Dictionary<int, List<string>>
        {
            { 1, new List<string> { "When did Bulgaria join the EU?", "2007" } },
            { 2, new List<string> { "Porsche is a brand of car that originated in what country?", "Germany" } },
            { 3, new List<string> { "Who was the first human to travel into space?", "Yuri Gagarin" } },
            { 4, new List<string> { "The Roman numeral \"D\" stands for what number?", "500" } },
            { 5, new List<string> { "What is the name for the Greek goddess of victory?", "Nike" } },
            { 6, new List<string> { "According to Greek mythology which Gorgon had snakes for hair and could turn onlookers into stone?", "Medusa" } },
            { 7, new List<string> { "The Roman numeral \"L\" stands for what number?", "50" } },
            { 8, new List<string> { "In what year did the Titanic sink?", "1912" } },
            { 9, new List<string> { "According to Greek mythology, who was the goddess of beauty?", "Aphrodite" } },
            { 10, new List<string> { "Who was the first woman pilot to fly solo across the Atlantic?", "Amelia Earhart" } }
        };

        public QuizQuest(Position position)
            : base(position)
        {
            this.position = position;
        }

        public double StartGame()
        {
            var questionNumber = Generator.GetRandomNumber(1, 11);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(this.quizes[questionNumber][0]);
            string playerAnswer = Console.ReadLine();
            double result = 0;

            if (playerAnswer == this.quizes[questionNumber][1])
            {
                Console.WriteLine(Constants.CorrectMessage);
                result = 1;
            }
            else
            {
                Console.WriteLine(Constants.WrongMessage);
                result = -0.5;
            }

            Console.WriteLine();
            Console.WriteLine(Constants.ContinueMessage);
            Console.ReadLine();
            return result;
        }

        public double GetInteractionResult()
        {
            return this.StartGame();
        }
    }
}