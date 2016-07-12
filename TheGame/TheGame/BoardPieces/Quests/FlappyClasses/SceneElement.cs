using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardPieces.Quests.FlappyClasses
{
    abstract class SceneElement : GameElement
    {
        public override void UpdateNextFrame()
        {
            this.Column--;
        }
    }
}
