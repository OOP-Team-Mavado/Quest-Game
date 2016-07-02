namespace TheGame
{
    using TheGame.BoardInterfaces;
    using TheGame.Factories;

    public class StartGame
    {
        public static void Main()
        {
            GameFactory gameFactory = new GameFactory();
            IGame game = gameFactory.GetGame("MainGame");

            game.StartGame();
        }
    }
}