namespace TheGame.BoardPieces.Units
{
    using System;
    using System.Text;
    using TheGame.Helpers;
    using TheGame.Utils;

    public class Priest : AbstractHero
    {
        public Priest(Position position)
            : base(position)
        {
            this.Hp = Constants.PriestStartingHp;
            this.DisplaySymbol = Constants.PriestDisplaySymbol;
            this.Position = position;
            this.Explanation = string.Format("Priests have {0} hp and ...", this.Hp);
        }

        public override void UseSpecialItem(string itemType, string heroType)
        {
            throw new NotImplementedException();
        }

        public override void UseSpecialSkill()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                result.AppendLine();
            }

            result.AppendLine("                    You are an amazing PRIEST!");

            for (int i = 0; i < 3; i++)
            {
                result.AppendLine();
            }

            result.AppendLine("                                 ####    ");
            for (int i = 0; i < 4; i++)
            {
                result.AppendLine("                                 #  #    ");
            }

            result.AppendLine("                          ########  ########");
            result.AppendLine("                          #                #");
            result.AppendLine("                          ########  ########");

            for (int i = 0; i < 9; i++)
            {
                result.AppendLine("                                 #  #    ");
            }

            result.AppendLine("                                 ####    ");

            return result.ToString();
        }
    }
}