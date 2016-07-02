namespace TheGame.Factories
{
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces;
    using TheGame.Games;
    using TheGame.Units;
    using TheGame.Utils;

    public class GameFactory
    {
        private int idCounter = 0;

        public IGame GetGame(string gameName)
        {
            if (gameName == "MainGame")
            {
                MainGame game = new MainGame();
                Position outerBoxStarterPosition = new Position(0, 0);
                Box outerBorder = new Box(outerBoxStarterPosition, 80, 40);
                outerBorder.SetID(this.UseCurrentID());
                game.AddBoardElement(outerBorder);

                //// TODO: implement abstract logic for this
                int outerBoxWidthMiddle = 80 / 2;
                int outerBoxHeightMiddle = 40 / 2;
                int innerBoxPreferedWidth = 80 / 10;
                int innerBoxPreferedHeight = 40 / 10;
                int innerBoxStartingWidthCoo = outerBoxWidthMiddle - (innerBoxPreferedWidth / 2);
                int innerBoxStartingHeightCoo = outerBoxHeightMiddle - (innerBoxPreferedHeight / 2);

                Position innerBoxStarterPosition = new Position(innerBoxStartingWidthCoo, innerBoxStartingHeightCoo);

                Box innerBox = new Box(innerBoxStarterPosition, innerBoxPreferedWidth, innerBoxPreferedHeight);
                innerBox.SetID(this.UseCurrentID());
                game.AddBoardElement(innerBox);

                Position playerStartingPosition = new Position(5, 5);
                List<Position> playerPosition = new List<Position>();
                playerPosition.Add(playerStartingPosition);
                Preist player = new Preist(playerPosition);
                player.SetID(this.UseCurrentID());

                game.AddBoardElement(player);

                Position bombPosition = new Position(10, 10);
                List<Position> bombPositions = new List<Position>();
                bombPositions.Add(bombPosition);
                Bomb bomb = new Bomb(bombPositions, 1);
                bomb.SetID(this.UseCurrentID());
                game.AddBoardElement(bomb);

                return game;
            }

            IGame game1 = null;

            return game1;
        }

        private int UseCurrentID()
        {
            int currentId = this.idCounter;
            this.idCounter++;

            return currentId;
        }
    }
}