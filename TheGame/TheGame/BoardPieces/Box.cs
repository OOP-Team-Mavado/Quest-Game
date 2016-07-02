using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.Utils;
using TheGame.BoardInterfaces;


namespace TheGame.BoardPieces
{
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

        public Box(Position startingPosition,int length, int height)
        {
            this.startingPosition = startingPosition;
            this.topBorder = new List<Position>();
            this.botBorder = new List<Position>();
            this.leftBorder = new List<Position>();
            this.rightBorder = new List<Position>();
            initBorders(length, height);
        }

        private void initBorders(int length, int height)
        {
            

            //Creating top and bottom borders
            for (int i = 0; i < length; i++)
            {
                Position partOfTopBorder = new Position(this.startingPosition.getWidthCoo() + i,this.startingPosition.getDebthCoo());
                Position partOFBottomBorder = new Position(this.startingPosition.getWidthCoo() + i,this.startingPosition.getDebthCoo() + height -1);
                this.topBorder.Add(partOfTopBorder);
                this.botBorder.Add(partOFBottomBorder);
            }

            //Creating left and right borders
            for (int i = 0; i < height; i++)
            {
                Position partOfLeftBorder = new Position(this.startingPosition.getWidthCoo(),this.startingPosition.getDebthCoo() + i);
                Position partOfRightBorder = new Position(this.startingPosition.getWidthCoo() + length - 1, this.startingPosition.getDebthCoo() + i);
                this.leftBorder.Add(partOfLeftBorder);
                this.rightBorder.Add(partOfRightBorder);
            }
        }

        public List<List<Position>> getAllBorders()
        {
            List<List<Position>> allBorders = new List<List<Position>>();
            allBorders.Add(this.topBorder);
            allBorders.Add(this.botBorder);
            allBorders.Add(this.leftBorder);
            allBorders.Add(this.rightBorder);

            return allBorders;
        }


        public List<Position> getPositions()
        {
            List<Position> allPositions = this.topBorder.Concat(this.botBorder).Concat(this.leftBorder).Concat(this.rightBorder).ToList();
            return allPositions;
        }


        public int getID()
        {
            return this.id;
        }




        public void setID(int id)
        {
            this.id = id;
        }


        public string getDisplaySymbol()
        {
            return this.displaySymbol;
        }


        public ConsoleColor getColor()
        {
            return this.color;
        }
    }
}
