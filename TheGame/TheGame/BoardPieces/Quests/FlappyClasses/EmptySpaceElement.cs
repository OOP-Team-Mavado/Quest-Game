using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardPieces.Quests.FlappyClasses
{
    class EmptySpaceElement : SceneElement
    {
        public override ConsoleColor DisplayColor
        {
            get
            {
                return ConsoleColor.White;
            }
        }

        public override char DisplaySymbol
        {
            get
            {
                return ' ';
            }
        }
    }
}
