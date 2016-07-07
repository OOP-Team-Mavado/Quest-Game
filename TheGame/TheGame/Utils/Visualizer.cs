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
                string displaySymbol = currentPiece.DisplaySymbol;
                ConsoleColor color = currentPiece.Color;
                Position position = currentPiece.Position;

                if (currentPiece.Width == 1 && currentPiece.Height == 1)
                {
                    DrawSymbolAtPosition(displaySymbol, position, color);
                }
                else
                {
                    for (int h = 0; h < currentPiece.Width; h++)
                    {
                        Position partOfTopBorder = new Position(currentPiece.Position.GetWidthCoo() + h, currentPiece.Position.GetDebthCoo());
                        Position partOFBottomBorder = new Position(currentPiece.Position.GetWidthCoo() + h, currentPiece.Position.GetDebthCoo() + currentPiece.Height - 1);

                        DrawSymbolAtPosition(displaySymbol, partOfTopBorder, color);
                        if (currentPiece.DisplaySymbol == "W")
                        {
                            displaySymbol = "*";
                        }
                        DrawSymbolAtPosition(displaySymbol, partOFBottomBorder, color);
                    }

                    if (currentPiece.DisplaySymbol == "W")
                    {
                        displaySymbol = "W";
                    }

                    for (int j = 0; j < currentPiece.Height; j++)
                    {
                        Position partOfLeftBorder = new Position(currentPiece.Position.GetWidthCoo(), currentPiece.Position.GetDebthCoo() + j);
                        Position partOfRightBorder = new Position(currentPiece.Position.GetWidthCoo() + currentPiece.Width - 1, currentPiece.Position.GetDebthCoo() + j);

                        DrawSymbolAtPosition(displaySymbol, partOfLeftBorder, color);

                        if (currentPiece.DisplaySymbol == "W")
                        {
                            displaySymbol = "*";
                        }

                        DrawSymbolAtPosition(displaySymbol, partOfRightBorder, color);
                    }
                }




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