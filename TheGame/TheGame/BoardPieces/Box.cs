namespace TheGame.BoardPieces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Box : IDisplayPiece
    {
        private int id;
        private int width;
        private int height;
        private ConsoleColor color;
        private string displaySymbol;
        private List<Position> topBorder;
        private List<Position> botBorder;
        private List<Position> leftBorder;
        private List<Position> rightBorder;
        private Position startingPosition;

        public Box(Position startingPosition, int length, int height)
        {
            this.startingPosition = startingPosition;
            this.topBorder = new List<Position>();
            this.botBorder = new List<Position>();
            this.leftBorder = new List<Position>();
            this.rightBorder = new List<Position>();
            this.InitBorders(length, height);
            this.displaySymbol = Constants.BoxDisplaySymbol;
            this.color = Constants.BoxColor;
            this.width = length;
            this.height = height;
        }

        public Position Position
        {
            get
            {
                return startingPosition;
            }

            set
            {
                startingPosition = value;
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
                displaySymbol = Constants.BoxDisplaySymbol;
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
                color = Constants.BoxColor;
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

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
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
                height = value;
            }
        }

        public List<List<Position>> GetAllBorders()
        {
            List<List<Position>> allBorders = new List<List<Position>>();
            allBorders.Add(this.topBorder);
            allBorders.Add(this.botBorder);
            allBorders.Add(this.leftBorder);
            allBorders.Add(this.rightBorder);

            return allBorders;
        }

        public List<Position> GetPositions()
        {
            List<Position> allPositions = this.topBorder
                                                .Concat(this.botBorder)
                                                .Concat(this.leftBorder)
                                                .Concat(this.rightBorder)
                                                .ToList();

            return allPositions;
        }

        private void InitBorders(int length, int height)
        {
            //// Creating top and bottom borders and adding their position to the borders lists
            for (int i = 0; i < length; i++)
            {
                Position partOfTopBorder = new Position(this.startingPosition.GetWidthCoo() + i, this.startingPosition.GetDebthCoo());
                Position partOFBottomBorder = new Position(this.startingPosition.GetWidthCoo() + i, this.startingPosition.GetDebthCoo() + height - 1);
                this.topBorder.Add(partOfTopBorder);
                this.botBorder.Add(partOFBottomBorder);
            }

            //// Creating left and right borders and adding their position to the borders lists
            for (int i = 0; i < height; i++)
            {
                Position partOfLeftBorder = new Position(this.startingPosition.GetWidthCoo(), this.startingPosition.GetDebthCoo() + i);
                Position partOfRightBorder = new Position(this.startingPosition.GetWidthCoo() + length - 1, this.startingPosition.GetDebthCoo() + i);
                this.leftBorder.Add(partOfLeftBorder);
                this.rightBorder.Add(partOfRightBorder);
            }
        }
    }
}