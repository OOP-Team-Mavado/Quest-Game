namespace TheGame.BoardPieces.Units
{
    using System;
    public interface IUnit
    {
        void UseSpecialSkill();
        void UseSpecialItem(string itemType, string heroType);
    }
}