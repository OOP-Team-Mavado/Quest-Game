namespace TheGame.Factories
{
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces;
    using TheGame.Utils;

    public class WinAreaFactory
    {
        public static IDisplayPiece GetWinArea(Position startingTopLeftPosition, int width, int debth)
        {
            List<Position> winPositions = new List<Position>();
            int initialWidthCoo = startingTopLeftPosition.GetWidthCoo();
            int initialDebthCoo = startingTopLeftPosition.GetDebthCoo();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < debth; j++)
                {
                    Position winPosition = new Position(initialWidthCoo + i, initialDebthCoo - j);
                    winPositions.Add(winPosition);
                }
            }

            WinArea winArea = new WinArea(winPositions);

            return winArea;
        }
    }
}