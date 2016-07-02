namespace TheGame.Utils
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;

    public static class Visualizer
    {
        /// <summary>
        /// Draws all elements in the start of the game
        /// </summary>
        /// <param name="allPieces"></param>
        public static void DrawEverything(List<IDisplayPiece> allPieces)
        {
            Console.Clear();

            for (int i = 0; i < allPieces.Count; i++)
            {
                IDisplayPiece currentPiece = allPieces[i];
                string displaySymbol = currentPiece.GetDisplaySymbol();
                List<Position> positions = currentPiece.GetPositions();
                ConsoleColor color = currentPiece.GetColor();

                for (int j = 0; j < positions.Count; j++)
                {
                    DrawSymbolAtPosition(displaySymbol, positions[j], color);
                }
            }
        }

        public static void EraseDisplayPieceFromConsole(IDisplayPiece targetedForErasing)
        {
            List<Position> positionsToErase = targetedForErasing.GetPositions();

            for (int i = 0; i < positionsToErase.Count; i++)
            {
                DrawSymbolAtPosition(" ", positionsToErase[i], ConsoleColor.Black);
            }
        }

        public static void DrawDisplayPieceOnConsole(IDisplayPiece pieceToDraw)
        {
            List<Position> positionsToDraw = pieceToDraw.GetPositions();
            string drawSymbol = pieceToDraw.GetDisplaySymbol();
            ConsoleColor color = pieceToDraw.GetColor();

            for (int i = 0; i < positionsToDraw.Count; i++)
            {
                DrawSymbolAtPosition(drawSymbol, positionsToDraw[i], color);
            }
        }

        private static void DrawSymbolAtPosition(string symbol, Position position, ConsoleColor color)
        {
            Console.SetCursorPosition(position.GetWidthCoo(), position.GetDebthCoo());
            Console.ForegroundColor = color;
            Console.Write(symbol);

            // Set to avoid the visual glitches caused by the underscore ("_") ;
            Console.SetCursorPosition(0, 41);
        }
    }
}