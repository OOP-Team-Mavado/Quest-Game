namespace TheGame.BoardPieces.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheGame.BoardInterfaces;
    using TheGame.Utils;

    public abstract class AbstractItem : IDisplayPiece
    {
        private int id;
        private int width;
        private int height;
        private string displaySymbol;
        private Position position;
        private ConsoleColor color;

        public AbstractItem(Position position)
        {
            this.position = position;
            //this.displaySymbol = Constants.BombDisplaySymbol;
            //this.color = Constants.BombColor;
            //this.width = 1;
            //this.height = 1;
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

            //private set
            //{
            //    displaySymbol = Constants.BombDisplaySymbol;
            //}
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }

            //private set
            //{
            //    color = Constants.BombColor;
            //}
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
    }
}
