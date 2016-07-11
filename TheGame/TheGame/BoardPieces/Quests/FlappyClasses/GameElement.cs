using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardPieces.Quests.FlappyClasses
{
    abstract class GameElement
    {
        public abstract void UpdateNextFrame();

        public int Row { get; set; }
        public int Column { get; set; }

        public abstract char DisplaySymbol { get; }
        public abstract ConsoleColor DisplayColor { get; }
    }
}
