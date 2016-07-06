namespace TheGame.BoardPieces.Units
{
    using System;
    using System.Collections.Generic;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Magician : AbstractHero
    {
        public Magician(Position position)
             : base(position)
        {
            //// TODO: add something that makes Priest and Magician different. 
            //// TODO: add more classes
            this.Hp = Constants.MagicianStartingHp;
            this.DisplaySymbol = Constants.MagicianDisplaySymbol;
            this.Position = position;
            this.Explanation = string.Format("Magicians have {0} hp and ...", this.Hp);
        }

        public override void UseSpecialItem(string itemType, string heroType)
        {
            throw new NotImplementedException();
        }

        public override void UseSpecialSkill()
        {
            this.Hp += 1;
        }
    }
}