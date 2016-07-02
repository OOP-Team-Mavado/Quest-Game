using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.Utils;

namespace TheGame.AbstractClasses
{
    public abstract class BoardTraverser
    {
        protected IDisplayPiece getPieceAtPosition(Position targetPosition,List<IDisplayPiece> boardPieces)
        {
            for (int i = 0; i < boardPieces.Count; i++)
            {
                List<Position> currentBoardPiecePositions = boardPieces[i].getPositions();

                for (int j = 0; j < currentBoardPiecePositions.Count; j++)
                {
                    bool widthCooMatches = targetPosition.getWidthCoo() == currentBoardPiecePositions[j].getWidthCoo();
                    bool debthCooMatches = targetPosition.getDebthCoo() == currentBoardPiecePositions[j].getDebthCoo();

                    if(widthCooMatches && debthCooMatches)
                    {
                        return boardPieces[i];
                    }
                }
            }

            return null;
        }
    }
}
