using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.Games;
using TheGame.BoardPieces;
using TheGame.Utils;
using TheGame.Units;

namespace TheGame.Factories
{
    public class GameFactory
    {
        private int idCounter = 0;


        public IGame getGame(string gameName)
        {
            

            if (gameName == "MainGame")
            {
                MainGame game = new MainGame();
                Position outerBoxStarterPosition = new Position(0, 0);
                Box outerBorder = new Box(outerBoxStarterPosition, 80, 40);
                outerBorder.setID(useCurrentID());
                game.addBoardElement(outerBorder);

                //Todo implement abstract logic for this
                int outerBoxWidthMiddle = 80 / 2;
                int outerBoxHeightMiddle = 40 / 2;
                int innerBoxPreferedWidth = 80 / 10;
                int innerBoxPreferedHeight = 40 / 10;
                int innerBoxStartingWidthCoo = outerBoxWidthMiddle - innerBoxPreferedWidth / 2;
                int innerBoxStartingHeightCoo = outerBoxHeightMiddle - innerBoxPreferedHeight / 2;

                Position innerBoxStarterPosition = new Position(innerBoxStartingWidthCoo, innerBoxStartingHeightCoo);

                Box innerBox = new Box(innerBoxStarterPosition, innerBoxPreferedWidth, innerBoxPreferedHeight);
                innerBox.setID(useCurrentID());
                game.addBoardElement(innerBox);

                Position playerStartingPosition = new Position(5,5);
                List<Position> playerPosition = new List<Position>();
                playerPosition.Add(playerStartingPosition);
                Preist player = new Preist(playerPosition);
                player.setID(useCurrentID());

                game.addBoardElement(player);

                Position bombPosition = new Position(10, 10);
                List<Position> bombPositions = new List<Position>();
                bombPositions.Add(bombPosition);
                Bomb bomb = new Bomb(bombPositions, 1);
                bomb.setID(useCurrentID());
                game.addBoardElement(bomb);



                return game;



            }
            IGame game1 = null;

            return game1;
        }

        private int useCurrentID()
        {
            int currentId = this.idCounter;
            this.idCounter++;

            return currentId;
        }
    }
}
