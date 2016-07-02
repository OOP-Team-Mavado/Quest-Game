using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardPieces;
using TheGame.BoardInterfaces;

namespace TheGame.Utils
{
    public static class Visualizer
    {

        public static void drawEverything(List<IDisplayPiece> allPieces)
        {
            Console.Clear();

            for (int i = 0; i < allPieces.Count; i++)
            {
                IDisplayPiece currentPiece = allPieces[i];
                string displaySymbol = currentPiece.getDisplaySymbol();
                List<Position> positions = currentPiece.getPositions();
                ConsoleColor color = currentPiece.getColor();

                for (int j = 0; j < positions.Count; j++)
                {
                    drawSymbolAtPosition(displaySymbol, positions[j],color);
                }
            }
        }

        public static void eraseDisplayPieceFromConsole(IDisplayPiece targetedForErasing)
        {
            List<Position> positionsToErase = targetedForErasing.getPositions();

            for (int i = 0; i < positionsToErase.Count; i++)
            {
                drawSymbolAtPosition(" ", positionsToErase[i],ConsoleColor.Black);
            }
        }

        public static void drawDisplayPieceOnConsole(IDisplayPiece pieceToDraw)
        {
            List<Position> positionsToDraw = pieceToDraw.getPositions();
            string drawSymbol = pieceToDraw.getDisplaySymbol();
            ConsoleColor color = pieceToDraw.getColor();

            for (int i = 0; i < positionsToDraw.Count; i++)
            {
                drawSymbolAtPosition(drawSymbol, positionsToDraw[i],color);
            }
        }

        private static void drawSymbolAtPosition(string symbol, Position position, ConsoleColor color)
        {
            Console.SetCursorPosition(position.getWidthCoo(), position.getDebthCoo());
            Console.ForegroundColor = color;
            Console.Write(symbol);

            //Set to avoid the visual glitches caused by the underscore ("_") ;
            Console.SetCursorPosition(0, 41);

        }
    }
}
