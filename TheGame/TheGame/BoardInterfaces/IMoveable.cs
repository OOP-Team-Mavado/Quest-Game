using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.BoardInterfaces
{
    public interface IMoveable
    {
        string Move(ConsoleKeyInfo userInput);
    }
}
