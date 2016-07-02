namespace TheGame.BoardInterfaces
{
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Utils;

    public abstract class BoardTraverser
    {
        protected IDisplayPiece GetPieceAtPosition(Position targetPosition, List<IDisplayPiece> boardPieces)
        {
            for (int i = 0; i < boardPieces.Count; i++)
            {
                List<Position> currentBoardPiecePositions = boardPieces[i].GetPositions();

                for (int j = 0; j < currentBoardPiecePositions.Count; j++)
                {
                    bool widthCooMatches = targetPosition.GetWidthCoo() == currentBoardPiecePositions[j].GetWidthCoo();
                    bool debthCooMatches = targetPosition.GetDebthCoo() == currentBoardPiecePositions[j].GetDebthCoo();

                    if (widthCooMatches && debthCooMatches)
                    {
                        return boardPieces[i];
                    }
                }
            }

            return null;
        }
    }
}