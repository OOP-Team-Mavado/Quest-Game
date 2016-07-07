namespace TheGame.BoardInterfaces
{
    using System;
    using System.Collections.Generic;
    using TheGame.Utils;

    public interface IDisplayPiece
    {
        Position Position
        {
            get;
            set;
        }

        string DisplaySymbol
        {
            get;
        }

        ConsoleColor Color
        {
            get;
        }

        int Id
        {
            get;
            set;
        }

        int Width
        {
            get;
            set;
        }

        int Height
        {
            get;
            set;
        }
    }
}