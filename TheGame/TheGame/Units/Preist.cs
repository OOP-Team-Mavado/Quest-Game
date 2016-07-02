using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.BoardInterfaces;
using TheGame.Utils;

namespace TheGame.Units
{
    class Preist : AbstractHero
    {


        public Preist(List<Position> position)
        {
            this.hp = 5;
            this.displaySymbol = "P";
            this.position = position;
        }

        public override void useSpecial()
        {
            this.hp += 1;
        }


        
    }
}
