namespace TheGame.Units
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
        }

        public override void UseSpecial()
        {
            this.hp += 1;
        }
    }
}