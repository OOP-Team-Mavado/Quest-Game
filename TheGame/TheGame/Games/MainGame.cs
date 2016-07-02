namespace TheGame.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Units;
    using TheGame.Utils;

    public class MainGame : BoardTraverser, IGame
    {
        private List<IDisplayPiece> boardElements;
        private int playerScore;
        private bool gameIsActive = false;
        private AbstractHero player;

        public MainGame()
        {
            this.boardElements = new List<IDisplayPiece>();
            //// TODO probably need to instantiate the player and the starting position in the constructor
        }

        public int StartGame()
        {
            Visualizer.DrawEverything(this.boardElements);
            this.gameIsActive = true;

            //// TODO set the player starting position somewhere better
            Position playerStartingPosition = new Position(Constants.PlayerStartingX, Constants.PlayerStartingY);

            this.player = (AbstractHero)GetPieceAtPosition(playerStartingPosition, this.boardElements);

            while (this.gameIsActive)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.Q)
                    {
                        this.gameIsActive = false;
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
            }

            return playerScore;
        }

        public void AddBoardElement(IDisplayPiece boardElement)
        {
            this.boardElements.Add(boardElement);
        }

        /// <summary>
        /// Moves Player to adjasent position
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
                int idOfInteractable = adjacentPiece.GetID();
                int interactionResult = adjacentInteractable.GetInteractionResult();
                this.playerScore += interactionResult;

                //// Removing IInteractable after it's interaction
                this.boardElements = this.boardElements.Where(x => x.GetID() != idOfInteractable).ToList();
                Visualizer.EraseDisplayPieceFromConsole(adjacentPiece);
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

        private void MoveAndRedrawBoardPiece(IDisplayPiece boardPiece, List<Position> newPosition)
        {
            //// TODO implement method moveAndRedrawBoardPiece
        }
    }
}