namespace TheGame.BoardPieces.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheGame.BoardInterfaces;
    using TheGame.Helpers;
    using TheGame.Utils;

    public abstract class AbstractHero : IUnit, IDisplayPiece, IMoveable
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

        public AbstractHero(Position position)
        {
            this.position = position;
            this.color = Constants.HeroColor;
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

        public int Hp
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public string DisplaySymbol
        {
            get
            {
                return displaySymbol;
            }

            protected set
            {
                displaySymbol = value;
            }
        }

        public string Explanation
        {
            get
            {
                return explanation;
            }

            set
            {
                explanation = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return color;
            }

            set
            {
                color = Constants.HeroColor;
            }
        }

        public double Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
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

        public abstract void UseSpecialSkill();

        public abstract void UseSpecialItem(string itemType, string heroType);

        public string Move(ConsoleKeyInfo userInput)
        {
            if (userInput.Key == ConsoleKey.UpArrow)
            {
                return "up";
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                return "down";
            }
            else if (userInput.Key == ConsoleKey.LeftArrow)
            {
                return "left";
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                return "right";
            }
            else
            {
                return "Q";
            }
        }
    }
}