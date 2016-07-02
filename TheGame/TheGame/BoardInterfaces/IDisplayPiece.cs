using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.Utils;

namespace TheGame.BoardInterfaces
{
    public interface IDisplayPiece
    {
         List<Position> getPositions();


         int getID();

         void setID(int id);

         string getDisplaySymbol();

         ConsoleColor getColor();
          
    }
}
