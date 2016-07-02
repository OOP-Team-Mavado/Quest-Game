using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.Utils;

namespace TheGame.BoardInterfaces
{
    interface IMovable 
    {
        void setPosition(List<Position> newPosition);
    }
}
