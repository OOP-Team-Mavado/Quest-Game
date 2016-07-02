namespace TheGame.BoardInterfaces
{
    using System;
    using System.Collections.Generic;
    using TheGame.Utils;

    public interface IDisplayPiece
    {
        List<Position> GetPositions();

        int GetID();

        void SetID(int id);

        string GetDisplaySymbol();

        ConsoleColor GetColor();
    }
}