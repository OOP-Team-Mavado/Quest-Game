namespace TheGame.BoardInterfaces
{
    using System;
    using System.Collections.Generic;
    using TheGame.Utils;

    public abstract class BoardTraverser : IGame
    {
        public abstract double StartGame();

        protected IDisplayPiece GetPieceAtPosition(Position targetPosition, List<IDisplayPiece> boardPieces)
        {
            for (int i = 0; i < boardPieces.Count; i++)
            {
                Position currentBoardPiecePosition = boardPieces[i].Position;

                bool widthCooMatches = targetPosition.GetWidthCoo() == currentBoardPiecePosition.GetWidthCoo();
                bool debthCooMatches = targetPosition.GetDebthCoo() == currentBoardPiecePosition.GetDebthCoo();

                if (widthCooMatches && debthCooMatches)
                {
                    return boardPieces[i];
                }

            }

            return null;
        }
    }
}