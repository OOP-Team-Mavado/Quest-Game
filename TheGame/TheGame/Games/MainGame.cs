namespace TheGame.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces.Units;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class MainGame : BoardTraverser, IGame
    {
        private List<IDisplayPiece> boardElements;
        private int playerScore;
        private int gameStatus;

        //// Game status 0 will mean active game. Game status 1 will mean won game. Game status -1 will mean lost game
        private AbstractHero player;

        private int minimumWinScore;
        private Position positionOfBorderAroundWinArea;

        public MainGame()
        {
            this.boardElements = new List<IDisplayPiece>();
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

        public int StartGame()
        {
            Visualizer.DrawEverything(this.boardElements);
            this.gameStatus = 0;

            //// TODO set the player starting position somewhere better
            Position playerStartingPosition = new Position(Constants.PlayerStartingX, Constants.PlayerStartingY);

            this.player = (AbstractHero)GetPieceAtPosition(playerStartingPosition, this.boardElements);

            while (this.gameStatus == 0)
            {
                if (this.playerScore >= minimumWinScore)
                {
                    IDisplayPiece borderAroundWinArea = GetPieceAtPosition(this.positionOfBorderAroundWinArea, this.boardElements);

                    if (borderAroundWinArea != null)
                    {
                        RemoveDisplayPiece(borderAroundWinArea);
                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.Q)
                    {
                        this.gameStatus = -1;
                    }
                    else if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        this.TryMovingToDirection("up");
                    }
                    else if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        this.TryMovingToDirection("down");
                    }
                    else if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        this.TryMovingToDirection("left");
                    }
                    else if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        this.TryMovingToDirection("right");
                    }
                }

                if (this.player.GetHP() <= 0)
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
            int debthOfAdjacent = player.GetPositions()[0].GetDebthCoo();
            int widthOfAdjacent = player.GetPositions()[0].GetWidthCoo();

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

                int interactionResult = adjacentInteractable.GetInteractionResult();

                if (interactionResult >= Constants.WinIndicator)
                {
                    this.gameStatus = 1;
                }
                else if (interactionResult < 0)
                {
                    int playerHP = this.player.GetHP();
                    int playerNewHp = playerHP + interactionResult;
                    this.player.SetHP(playerHP);
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
                List<Position> newPosition = new List<Position>();
                newPosition.Add(adjacentPosition);
                this.player.SetPosition(newPosition);
                Visualizer.DrawDisplayPieceOnConsole(this.player);
            }
        }

        private void RemoveDisplayPiece(IDisplayPiece displayPiece)
        {
            int idOfDisplayPiece = displayPiece.GetID();
            this.boardElements = this.boardElements.Where(x => x.GetID() != idOfDisplayPiece).ToList();
            Visualizer.EraseDisplayPieceFromConsole(displayPiece);
        }
    }
}