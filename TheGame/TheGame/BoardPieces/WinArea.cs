namespace TheGame.BoardPieces
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class WinArea : IDisplayPiece, IInteractable
    {
        private List<Position> winAreas = new List<Position>();
        private int id;
        private int width;
        private int height;
        private string displaySymbol;
        private Position initialPositions;
        private ConsoleColor color;

        public WinArea(Position position)
        {
            this.initialPositions = position;
            this.displaySymbol = Constants.WinAreaDisplaySymbol;
            this.color = Constants.WinAreaColor;
            this.width = Constants.BoxWidth / 10 - 2;
            this.height = Constants.BoxHeight / 10 - 2;
        }

        public Position Position
        {
            get
            {
                return initialPositions;
            }

            set
            {
                initialPositions = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string DisplaySymbol
        {
            get
            {
                return displaySymbol;
            }

            private set
            {
                displaySymbol = Constants.WinAreaDisplaySymbol;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }

            private set
            {
                color = Constants.WinAreaColor;
            }
        }

        public List<Position> WinAreas
        {
            get
            {
                return winAreas;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = Constants.BoxWidth / 10 - 2;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = Constants.BoxHeight / 10 - 2;
            }
        }

        public void WinAreaAddPosition(Position initialPositions)
        {
            this.winAreas.Add(initialPositions);
        }

        public List<Position> GetPositions()
        {
            return winAreas;
        }

        public double GetInteractionResult()
        {
            return Constants.WinIndicator;
        }
    }
}