namespace TheGame.Utils
{
    using BoardPieces;
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
                DrawDisplayPieceOnConsole(currentPiece);

            }
           
        }

        public static void EraseDisplayPieceFromConsole(IDisplayPiece targetedForErasing)
        {
            Position positionsToErase = targetedForErasing.Position;
            DrawSymbolAtPosition(" ", positionsToErase, ConsoleColor.Black);

        }

        public static void DrawDisplayPieceOnConsole(IDisplayPiece pieceToDraw)
        {
            Position positionsToDraw = pieceToDraw.Position;
            string drawSymbol = pieceToDraw.DisplaySymbol;
            ConsoleColor color = pieceToDraw.Color;

            DrawSymbolAtPosition(drawSymbol, positionsToDraw, color);

        }

        public static void DrawSymbolAtPosition(string symbol, Position position, ConsoleColor color)
        {
            Console.SetCursorPosition(position.GetWidthCoo(), position.GetDebthCoo());
            Console.ForegroundColor = color;
            Console.Write(symbol);


            //// set to avoid the visual glitches caused by the underscore ("_") ;
            Console.SetCursorPosition(0, 41);
        }
    }
}