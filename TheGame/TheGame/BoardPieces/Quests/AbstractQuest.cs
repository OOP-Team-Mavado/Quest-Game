using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.BoardInterfaces;
using TheGame.Helpers;
using TheGame.Utils;

namespace TheGame.BoardPieces.Quests
{
    public abstract class AbstractQuest : IDisplayPiece
    {
        private Position position;
        private int hp;
        private int id;
        private int width;
        private int height;
        private double score;
        private ConsoleColor color;
        private string displaySymbol;
        private string explanation;

        public AbstractQuest(Position position)
        {
            this.position = position;
            this.color = Constants.QuestsColor;
            this.displaySymbol = Constants.QuestDisplaySymbol;
            this.width = 1;
            this.height = 1;
        }

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string DisplaySymbol
        {
            get
            {
                return displaySymbol;
            }

            private set
            {
                displaySymbol = Constants.QuestDisplaySymbol;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }

            private set
            {
                color = Constants.QuestsColor;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = 1;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = 1;
            }
        }
    }
}
