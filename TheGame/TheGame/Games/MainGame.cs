using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.AbstractClasses;
using TheGame.Utils;
using TheGame.Units;

namespace TheGame.Games
{
    public class MainGame : BoardTraverser, IGame
    {
        private List<IDisplayPiece> boardElements;
        private int score;
        private bool gameIsActive = false;
        private AbstractHero player;
        
      


        public MainGame()
        {
            this.boardElements = new List<IDisplayPiece>();
            //TODO probably need to instantiate the player and the starting position in the constructor
 
        }

        public int startGame()
        {
            Visualizer.drawEverything(this.boardElements);
            this.gameIsActive = true;


            //TODO set the player starting position somewhere better
            Position playerStartingPosition = new Position(5, 5);

            this.player = (AbstractHero)getPieceAtPosition(playerStartingPosition, this.boardElements);



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
                        tryMovingToDirection("up");
                    }
                    else if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        tryMovingToDirection("down");
                    }else if(userInput.Key == ConsoleKey.LeftArrow)
                    {
                        tryMovingToDirection("left");
                    }
                    else if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        tryMovingToDirection("right");
                    }


                }
            }

            return score;
        }

        private void moveAndRedrawBoardPiece(IDisplayPiece boardPiece, List<Position> newPosition)
        {

        }

        private void tryMovingToDirection(string direction)
        {
            Position adjacentPosition = positionAdjacentToPlayer(player, direction);
            IDisplayPiece adjacentPiece = getPieceAtPosition(adjacentPosition, this.boardElements);
            if (adjacentPiece is IInteractable)
            {
                IInteractable adjacentInteractable = (IInteractable)adjacentPiece;
                int idOfInteractable = adjacentPiece.getID();
                int interactionResult = adjacentInteractable.getInteractionResult();
                this.score += interactionResult;


                //Removing IInteractable after it's interaction
                this.boardElements = this.boardElements.Where(x => x.getID() != idOfInteractable).ToList();
                Visualizer.eraseDisplayPieceFromConsole(adjacentPiece);

            }
            else if (adjacentPiece == null)
            {
                //Moving player
                Visualizer.eraseDisplayPieceFromConsole(player);
                List<Position> newPosition = new List<Position>();
                newPosition.Add(adjacentPosition);
                this.player.setPosition(newPosition);
                Visualizer.drawDisplayPieceOnConsole(player);
            }
        }

        private Position positionAdjacentToPlayer(IDisplayPiece player,string direction)
        {
            int debthOfAdjacent = player.getPositions()[0].getDebthCoo();
            int widthOfAdjacent = player.getPositions()[0].getWidthCoo();

            if(direction.ToLower() == "up")
            {
                debthOfAdjacent--;
            }else if(direction.ToLower() == "down")
            {
                debthOfAdjacent++;
            }else if(direction.ToLower() == "left")
            {
                widthOfAdjacent--;
            }else if(direction.ToLower() == "right")
            {
                widthOfAdjacent++;
            }

            return new Position(widthOfAdjacent, debthOfAdjacent);
        }

        public void addBoardElement(IDisplayPiece boardElement)
        {
            this.boardElements.Add(boardElement);
        }
    }
}
