namespace TheGame.BoardPieces
{
    using System;
    using System.Collections.Generic;
    
    using TheGame.BoardInterfaces;
    using TheGame.Utils;
    using TheGame.Helpers;

    public class WinArea : IDisplayPiece, IInteractable
    {
        private List<Position> positions;
        private int id;
        private string displaySymbol = "W";
        private ConsoleColor displayColor = ConsoleColor.Yellow;

        public WinArea(List<Position> initialPositions)
        {
            this.positions = initialPositions;
        }


        public int GetInteractionResult()
        {
            return Constants.WinIndicator;
        }

        public List<Utils.Position> GetPositions()
        {
            return this.positions;
        }

        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public string GetDisplaySymbol()
        {
            return this.displaySymbol;
        }

        public ConsoleColor GetColor()
        {
            return this.displayColor;
        }
    }
}
