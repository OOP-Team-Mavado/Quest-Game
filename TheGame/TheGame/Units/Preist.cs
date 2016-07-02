namespace TheGame.Units
{
    using System.Collections.Generic;
    using TheGame.Utils;

    public class Preist : AbstractHero
    {
        public Preist(List<Position> position)
        {
            this.hp = 5;
            this.displaySymbol = "P";
            this.position = position;
        }

        public override void UseSpecial()
        {
            this.hp += 1;
        }
    }
}