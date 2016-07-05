namespace TheGame.BoardPieces.Units
{
    using System;
    using System.Collections.Generic;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Magician : AbstractHero
    {

        public Magician(List<Position> position)
        {
            //// TODO: add something that makes Priest and Magician different. 
            //// TODO: add more classes
            this.hp = Constants.MagicianStartingHp;
            this.displaySymbol = Constants.MagicianDisplaySymbol;
            this.position = position;
            this.explanation = string.Format("Magicians have {0} hp and ...", this.hp);
        }

        public override void UseSpecial()
        {
            this.hp += 1;
        }
    }
}