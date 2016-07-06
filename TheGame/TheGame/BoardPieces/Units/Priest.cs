namespace TheGame.BoardPieces.Units
{
    using System;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Priest : AbstractHero
    {
        public Priest(Position position)
            : base(position)
        {
            this.Hp = Constants.PriestStartingHp;
            this.DisplaySymbol = Constants.PriestDisplaySymbol;
            this.Position = position;
            this.Explanation = string.Format("Priests have {0} hp and ...", this.Hp);
        }

        public override void UseSpecialItem(string itemType, string heroType)
        {
            throw new NotImplementedException();
        }

        public override void UseSpecialSkill()
        {
            throw new NotImplementedException();
        }
    }
}