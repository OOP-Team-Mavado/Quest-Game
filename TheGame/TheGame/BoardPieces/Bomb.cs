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
        private ConsoleColor bombColor = Constants.BombColor;
        private string displaySymbol = Constants.BombDisplaySymbol;
        private List<Position> position;
        private int amountOfDamageItInflicts;

        public Bomb(List<Position> position, int damage)
        {
            this.position = position;
            this.amountOfDamageItInflicts = damage;
        }

        public void SetID(int id)
        {
            this.id = id;
        }

        public int GetInteractionResult()
        {
            return this.amountOfDamageItInflicts;
        }

        public List<Position> GetPositions()
        {
            return this.position;
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
            return this.bombColor;
        }
    }
}