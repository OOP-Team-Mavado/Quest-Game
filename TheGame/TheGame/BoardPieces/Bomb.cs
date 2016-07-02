using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.Utils;


namespace TheGame.BoardPieces
{
    public class Bomb : IDisplayPiece,IInteractable
    {
        private int id;
        private ConsoleColor color = ConsoleColor.Red;
        private string displaySymbol = "B";
        private List<Position> position;
        private int amountOfDamageItInflicts;

        public Bomb(List<Position> position, int damage)
        {
            this.position = position;
            this.amountOfDamageItInflicts = damage;

        }


        public int getInteractionResult()
        {
            return amountOfDamageItInflicts;
        }

        public List<Position> getPositions()
        {
            return this.position;
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
