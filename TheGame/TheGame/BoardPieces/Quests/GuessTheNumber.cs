namespace TheGame.BoardPieces.Quests
{
    using System;
    using BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class GuessTheNumber : AbstractQuest, IGame, IInteractable
    {
        private Position position;

        public GuessTheNumber(Position position)
            : base(position)
        {
            this.position = position;
            this.DisplaySymbol = "N";
        }

        public override double StartGame()
        {
            
            string magicNumber = Generator.GetRandomNumber(0, 10).ToString();
            double result = 0;

            Console.Clear();
            Console.WriteLine(Constants.MasterMessageGuessNumber);
            string playersAnswer = Console.ReadLine();

            if(magicNumber == playersAnswer)
            {
                Console.WriteLine(Constants.CorrectMessage);
                result = 1;
            }
            else
            {
                Console.WriteLine(Constants.WrongMessage);
                Console.WriteLine(Constants.SecondChanceMessage);
                if (int.Parse(magicNumber) > 4)
                {
                    Console.WriteLine(Constants.SecretOfMasters, "bigger", 4);
                }
                else
                {
                    Console.WriteLine(Constants.SecretOfMasters, "smaller", 5);
                }
                string secondChance = Console.ReadLine();
                if(magicNumber == secondChance)
                {
                    Console.WriteLine(Constants.CorrectMessage);
                    result = 0.5;
                }
                else
                {
                    Console.WriteLine(Constants.WrongMessage);
                    result = -0.5;
                }
            }

            Console.WriteLine();
            Console.WriteLine(Constants.ContinueMessage);
            Console.ReadLine();
            return result;
        }
    }
}
