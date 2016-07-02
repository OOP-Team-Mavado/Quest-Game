using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.Utils;


namespace TheGame.Units
{
    public abstract class AbstractHero : IUnit,IMovable,IDisplayPiece
    {

        protected List<Position> position;
        protected int hp;
        protected int id;
        protected ConsoleColor color = ConsoleColor.Cyan;
        protected string displaySymbol;

        public List<Position> getPositions()
        {
            return this.position;
        }

        public void setPosition(List<Position> newPosition)
        {
            this.position = newPosition;
        }

        public int getID()
        {
            return this.id;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public int getHP()
        {
            return this.hp;
        }


        public abstract void useSpecial();
        
            
        


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
