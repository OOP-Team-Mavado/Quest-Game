namespace TheGame
{
    using System;
    using TheGame.BoardInterfaces;
    using TheGame.Factories;

    public class StartGame
    {
        public static void Main()
        {
            Console.SetWindowSize(80, 44);
            //// TODO: make initial screen where to choose Priest or Magician
            //// TODO: explain how the game works after selection of Priest or Magician
            GameFactory gameFactory = new GameFactory();
            IGame game = gameFactory.GetGame("MainGame");
            //// TODO: show points
            //// TODO: make highscore
            game.StartGame();
        }
    }
}