namespace TheGame.Games
{
    using BoardPieces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces.Units;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class MainGame : BoardTraverser
    {
        private List<IDisplayPiece> boardElements;
        private List<Position> winAreaPoints;
        private double playerScore;
        private int gameStatus;

        //// Game status 0 will mean active game. Game status 1 will mean won game. Game status -1 will mean lost game
        private AbstractHero player;

        private int minimumWinScore;
        private Position positionOfBorderAroundWinArea;

        public MainGame()
        {
            this.boardElements = new List<IDisplayPiece>();
            this.winAreaPoints = new List<Position>();
            //// TODO probably need to instantiate the player and the starting position in the constructor
        }

        public void SetMinimumWinScore(int minimumWinScore)
        {
            this.minimumWinScore = minimumWinScore;
        }

        public void SetInitPositionOfBorderAroundWinArea(Position initPositionOfBorderAroundWinArea)
        {
            this.positionOfBorderAroundWinArea = initPositionOfBorderAroundWinArea;
        }

        public override double StartGame()
        {
            Visualizer.DrawEverything(this.boardElements);
            this.gameStatus = 0;

            this.winAreaPoints = ((WinArea)this.boardElements
                                                .Find(x => x.DisplaySymbol == "W")).GetPositions();

            Position playerStartingPosition = new Position(Constants.PlayerStartingX, Constants.PlayerStartingY);
            this.player = (AbstractHero)GetPieceAtPosition(playerStartingPosition, this.boardElements);

            while (this.gameStatus == 0)
            {
                if (this.playerScore >= minimumWinScore)
                {
                    int widthCooOfDoor = this.positionOfBorderAroundWinArea.GetWidthCoo();
                    int debtCooOfDoor = this.positionOfBorderAroundWinArea.GetDebthCoo() + 1;
                    Position positionOfDoorToWin = new Position(widthCooOfDoor, debtCooOfDoor);

                    IDisplayPiece doorToWinArea = GetPieceAtPosition(positionOfDoorToWin, this.boardElements);
                    if (doorToWinArea != null)
                    {
                        RemoveDisplayPiece(doorToWinArea);
                    }
                    
                }

                //// TODO: make every move to remove 0.1 points from the player score and explain it at the begining so that the players think on how they play and there is gamification to the movement as well
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.Q)
                    {
                        this.gameStatus = -1;
                    }
                    else
                    {
                        this.TryMovingToDirection(this.player.Move(userInput));
                    }
                }

                if (this.player.Hp <= 0)
                {
                    this.gameStatus = -1;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if (gameStatus == 1)
            {
                Console.WriteLine("Congratulations you won!");
            }
            else if (gameStatus == -1)
            {
                Console.WriteLine("You lost the game");
            }

            Console.ReadLine();

            return playerScore;
        }

        public void AddBoardElement(IDisplayPiece boardElement)
        {
            this.boardElements.Add(boardElement);
        }

        /// <summary>
        /// Returns position adjacent to player
        /// </summary>
        /// <param name="player">IDisplayPiece</param>
        /// <param name="direction">string</param>
        /// <returns></returns>
        private Position PositionAdjacentToPlayer(IDisplayPiece player, string direction)
        {
            int debthOfAdjacent = player.Position.GetDebthCoo();
            int widthOfAdjacent = player.Position.GetWidthCoo();

            if (direction.ToLower() == "up")
            {
                debthOfAdjacent--;
            }
            else if (direction.ToLower() == "down")
            {
                debthOfAdjacent++;
            }
            else if (direction.ToLower() == "left")
            {
                widthOfAdjacent--;
            }
            else if (direction.ToLower() == "right")
            {
                widthOfAdjacent++;
            }

            return new Position(widthOfAdjacent, debthOfAdjacent);
        }

        /// <summary>
        /// Moves player to position adjacent to him and checks whether new position is interactable
        /// Adds the Result of the Interactable position to the player score
        /// </summary>
        /// <param name="direction">string</param>
        private void TryMovingToDirection(string direction)
        {
            Position adjacentPosition = this.PositionAdjacentToPlayer(this.player, direction);
            IDisplayPiece adjacentPiece = GetPieceAtPosition(adjacentPosition, this.boardElements);

            if (adjacentPiece is IInteractable)
            {
                IInteractable adjacentInteractable = (IInteractable)adjacentPiece;

                double interactionResult = adjacentInteractable.GetInteractionResult();

                if (interactionResult >= Constants.WinIndicator)
                {
                    this.gameStatus = 1;
                }
                else if (interactionResult < 0)
                {
                    int playerHP = this.player.Hp;
                    double playerNewHp = playerHP + interactionResult;
                    this.player.Hp = playerHP;
                }
                else
                {
                    this.playerScore += interactionResult;
                }

                Visualizer.DrawEverything(this.boardElements);

                RemoveDisplayPiece(adjacentPiece);
            }
            else if (adjacentPiece == null)
            {
                //// Moving player
                Visualizer.EraseDisplayPieceFromConsole(this.player);
                this.player.Position = adjacentPosition;
                Visualizer.DrawDisplayPieceOnConsole(player);
            }
        }

        private void RemoveDisplayPiece(IDisplayPiece displayPiece)
        {
            int idOfDisplayPiece = displayPiece.Id;
            this.boardElements = this.boardElements.Where(x => x.Id != idOfDisplayPiece).ToList();
            Visualizer.EraseDisplayPieceFromConsole(displayPiece);
        }
    }
}