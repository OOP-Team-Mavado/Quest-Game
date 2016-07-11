using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardPieces.Quests.FlappyClasses
{
    class ObstacleElement : GameElement
    {
        public override ConsoleColor DisplayColor
        {
            get
            {
                return ConsoleColor.Magenta;
            }
        }

        public override char DisplaySymbol
        {
            get
            {
                return '@';
            }
        }

        public override void UpdateNextFrame()
        {
            this.Column--;
        }
    }
}
