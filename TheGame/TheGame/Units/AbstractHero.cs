namespace TheGame.Units
{
    using System;
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.Utils;

    public abstract class AbstractHero : IUnit, IMovable, IDisplayPiece
    {
        protected List<Position> position;
        protected int hp;
        protected int id;
        protected ConsoleColor color = ConsoleColor.Cyan;
        protected string displaySymbol;

        public List<Position> GetPositions()
        {
            return this.position;
        }

        public void SetPosition(List<Position> newPosition)
        {
            this.position = newPosition;
        }

        public int GetID()
        {
            return this.id;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public int GetHP()
        {
            return this.hp;
        }

        public abstract void UseSpecial();

        public string GetDisplaySymbol()
        {
            return this.displaySymbol;
        }

        public ConsoleColor GetColor()
        {
            return this.color;
        }
    }
}