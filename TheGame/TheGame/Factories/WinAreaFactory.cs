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
            WinArea winArea = new WinArea(startingTopLeftPosition);
            int initialWidthCoo = startingTopLeftPosition.GetWidthCoo();
            int initialDebthCoo = startingTopLeftPosition.GetDebthCoo();

            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < debth - 1; j++)
                {
                    Position winPosition = new Position(initialWidthCoo + i - 1, initialDebthCoo - j - 1);
                    winArea.WinAreaAddPosition(winPosition);
                }
            }

            return winArea;
        }
    }
}