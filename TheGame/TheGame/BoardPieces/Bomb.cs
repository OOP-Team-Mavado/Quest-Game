namespace TheGame.BoardPieces
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Bomb : IDisplayPiece, IInteractable
    {
        private int id;
        private int width;
        private int height;
        private string displaySymbol;
        private int amountOfDamageItInflicts;
        private Position position;
        private ConsoleColor color;

        public Bomb(Position position, int damage)
        {
            this.position = position;
            this.amountOfDamageItInflicts = damage;
            this.displaySymbol = Constants.BombDisplaySymbol;
            this.color = Constants.BombColor;
            this.width = 1;
            this.height = 1;
        }

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
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
                displaySymbol = Constants.BombDisplaySymbol;
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
                color = Constants.BombColor;
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
                width = 1;
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
                height = 1;
            }
        }

        public double GetInteractionResult()
        {
            return -1;
        }
    }
}