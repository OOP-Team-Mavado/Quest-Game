namespace TheGame.Factories
{
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces;
    using TheGame.BoardPieces.Units;
    using TheGame.Games;
    using TheGame.Helpers;
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
                Box outerBorder = new Box(outerBoxStarterPosition, Constants.BoxWidth, Constants.BoxHeight);
                outerBorder.Id = this.UseCurrentID();
                game.AddBoardElement(outerBorder);

                //// TODO: implement abstract logic for this
                int outerBoxWidthMiddle = Constants.BoxWidth / 2;
                int outerBoxHeightMiddle = Constants.BoxHeight / 2;
                int innerBoxPreferedWidth = Constants.BoxWidth / 10 + 1;
                int innerBoxPreferedHeight = Constants.BoxHeight / 10 + 1;
                int innerBoxStartingWidthCoo = outerBoxWidthMiddle - (innerBoxPreferedWidth / 2) - 1 ;
                int innerBoxStartingHeightCoo = outerBoxHeightMiddle - (innerBoxPreferedHeight / 2) - 1;

                Position innerBoxStarterPosition = new Position(innerBoxStartingWidthCoo, innerBoxStartingHeightCoo);

                Box innerBox = new Box(innerBoxStarterPosition, innerBoxPreferedWidth, innerBoxPreferedHeight);
                innerBox.Id = this.UseCurrentID();
                game.AddBoardElement(innerBox);
                game.SetInitPositionOfBorderAroundWinArea(innerBoxStarterPosition);

                Position winAreaTopLeft = new Position(innerBoxStarterPosition.GetWidthCoo() + 1, innerBoxStarterPosition.GetDebthCoo() + 1);
                IDisplayPiece winArea = new WinArea(winAreaTopLeft);
                game.AddBoardElement(winArea);

                Position playerStartingPosition = new Position(Constants.PlayerStartingX, Constants.PlayerStartingY);

                AbstractHero player;
                int randNum = Generator.GetRandomNumber(1, 3);
                if (randNum == 1)
                {
                    player = new Priest(playerStartingPosition);
                }
                else
                {
                    player = new Magician(playerStartingPosition);
                }

                
                player.Id = this.UseCurrentID();

                game.AddBoardElement(player);

                //// TODO: add more quests
                List<Position> bombPositions = new List<Position>();

                var questNames = new List<string>
                {
                    "QuizQuest",
                    "FallingRocks"
                };
                var questsCount = questNames.Count;

                for (int j = 0; j < 4; j++)
                {
                    var xRand1 = 0;
                    var xRand2 = 0;
                    var yRand1 = 0;
                    var yRand2 = 0;
                    switch (j)
                    {
                        case 0:
                            xRand1 = 1;
                            xRand2 = innerBoxStartingWidthCoo - 1;
                            yRand1 = 1;
                            yRand2 = innerBoxStartingHeightCoo - 1;
                            break;
                        case 1:
                            xRand1 = innerBoxStartingWidthCoo + innerBoxPreferedWidth + 1;
                            xRand2 = Constants.BoxWidth - 1;
                            yRand1 = 1;
                            yRand2 = innerBoxStartingHeightCoo - 1;
                            break;
                        case 2:
                            xRand1 = 1;
                            xRand2 = innerBoxStartingWidthCoo - 1;
                            yRand1 = innerBoxStartingHeightCoo + innerBoxPreferedHeight + 1;
                            yRand2 = Constants.BoxHeight - 1;
                            break;
                        case 3:
                            xRand1 = innerBoxStartingWidthCoo + innerBoxPreferedWidth + 1;
                            xRand2 = Constants.BoxWidth - 1;
                            yRand1 = innerBoxStartingHeightCoo + innerBoxPreferedHeight + 1;
                            yRand2 = Constants.BoxHeight - 1;
                            break;
                        default:
                            break;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        IDisplayPiece quizQuest = QuestFactory.GetQuest(questNames[Generator.GetRandomNumber(0, questsCount)], this.UseCurrentID(), Generator.GetRandomNumber(xRand1, xRand2), Generator.GetRandomNumber(yRand1, yRand2));
                        game.AddBoardElement(quizQuest);
                    }

                    for (int k = 0; k < 5; k++)
                    {
                        Position bombPosition = new Position(Generator.GetRandomNumber(xRand1, xRand2), Generator.GetRandomNumber(yRand1, yRand2));
                        Bomb bomb = new Bomb(bombPosition, Generator.GetRandomNumber(1, 4));
                        bomb.Id = this.UseCurrentID();
                        game.AddBoardElement(bomb);
                    }
                }

                game.SetMinimumWinScore(2);

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