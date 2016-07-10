using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGame.Games;
using TheGame.Utils;

namespace TheGame.BoardPieces.Items
{
    class PointsItem : AbstractItem
    {
        private MainGame mainGame;
        private String typeOfPoints;

        public PointsItem(Position position) : base(position)
        {

        }

        public override String DisplaySymbol
        {
            get { return String.Format("Player {0}:{1}", this.typeOfPoints, this.mainGame.PlayerScore); }
        }

        public MainGame MainGame
        {
            set { this.mainGame = value; }
        }

        public String TypeOfPoints
        {
            set { this.typeOfPoints = value; }
        }


    }
}
