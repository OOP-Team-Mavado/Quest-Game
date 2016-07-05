namespace TheGame.BoardPieces.Units
{
    using System.Collections.Generic;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Priest : AbstractHero
    {
        public Priest(List<Position> position)
        {
            this.hp = Constants.PriestStartingHp;
            this.displaySymbol = Constants.PriestDisplaySymbol;
            this.position = position;
            this.explanation = string.Format("Priests have {0} hp and ...", this.hp);
        }

        public override void UseSpecial()
        {
            this.hp += 1;
        }
    }
}