namespace TheGame.BoardPieces.Units
{
    using System;
    using System.Text;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Magician : AbstractHero
    {
        public Magician(Position position)
             : base(position)
        {
            //// TODO: add something that makes Priest and Magician different. 
            //// TODO: add more classes
            this.Hp = Constants.MagicianStartingHp;
            this.DisplaySymbol = Constants.MagicianDisplaySymbol;
            this.Position = position;
            this.Explanation = string.Format("Magicians have {0} hp and ...", this.Hp);
        }

        public override void UseSpecialItem(string itemType, string heroType)
        {
            throw new NotImplementedException();
        }

        public override void UseSpecialSkill()
        {
            this.Hp += 1;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                result.AppendLine();
            }

            result.AppendLine("                    You are an amazing MAGICIAN!");

            for (int i = 0; i < 3; i++)
            {
                result.AppendLine();
            }

            result.AppendLine("                                 #    ");
            for (int i = 0, a = 1, b = 32; i < 3; i++, a += 2, b--)
            {
                result.AppendFormat(new string(' ', b));
                result.Append("#");
                result.Append(new String(' ', a));
                result.Append("#");
                result.AppendLine();
            }

            result.Append(new String(' ', 23));
            result.Append(new String('#', 7));
            result.Append(new String(' ', 7));
            result.Append(new String('#', 7));
            result.AppendLine();

            for (int i = 0, a = 24, b = 17; i < 4; i++, a++, b -= 2)
            {
                result.Append(new String(' ', a));
                result.Append("#");
                result.Append(new String(' ', b));
                result.Append("#");
                result.AppendLine();
            }

            for (int i = 0, a = 26, b = 13; i < 3; i++, a--, b += 2)
            {
                result.Append(new String(' ', a));
                result.Append("#");
                result.Append(new String(' ', b));
                result.Append("#");
                result.AppendLine();
            }

            result.Append(new String(' ', 23));
            result.Append(new String('#', 21));
            result.AppendLine();

            for (int i = 0; i < 13; i++)
            {
                result.Append(new String(' ', 32));
                result.Append("##");
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}