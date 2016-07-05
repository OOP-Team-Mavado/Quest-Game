namespace TheGame
{
    using TheGame.BoardInterfaces;
    using TheGame.Factories;

    public class StartGame
    {
        public static void Main()
        {
            //// TODO: set console dimensions to fit the field so we shouldn't scroll when playing the game
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