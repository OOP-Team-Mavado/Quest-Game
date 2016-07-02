using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.Utils;
using TheGame.BoardPieces;

using TheGame.Factories;
using TheGame.BoardInterfaces;

namespace TheGame
{
    class StartGame
    {
        static void Main(string[] args)
        {



            GameFactory gameFactory = new GameFactory();
            IGame game = gameFactory.getGame("MainGame");
           

            game.startGame();

        
       
            
        }
    }
}
