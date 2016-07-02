namespace TheGame.BoardPieces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.Utils;

    public class Box : IDisplayPiece
    {
        private int id;
        private ConsoleColor color = ConsoleColor.DarkGray;
        private string displaySymbol = "#";
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
        }

        public void SetID(int id)
        {
            this.id = id;
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
            List<Position> allPositions = this.topBorder.Concat(this.botBorder).Concat(this.leftBorder).Concat(this.rightBorder).ToList();
            return allPositions;
        }

        public int GetID()
        {
            return this.id;
        }

        public string GetDisplaySymbol()
        {
            return this.displaySymbol;
        }

        public ConsoleColor GetColor()
        {
            return this.color;
        }

        private void InitBorders(int length, int height)
        {
            //// Creating top and bottom borders
            for (int i = 0; i < length; i++)
            {
                Position partOfTopBorder = new Position(this.startingPosition.GetWidthCoo() + i, this.startingPosition.GetDebthCoo());
                Position partOFBottomBorder = new Position(this.startingPosition.GetWidthCoo() + i, this.startingPosition.GetDebthCoo() + height - 1);
                this.topBorder.Add(partOfTopBorder);
                this.botBorder.Add(partOFBottomBorder);
            }

            //// Creating left and right borders
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