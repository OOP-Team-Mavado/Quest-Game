namespace TheGame.Helpers
{
    using System;
    public class Constants
    {
        public const string BombDisplaySymbol = "B";
        public const string BoxDisplaySymbol = "#";
        public const string PriestDisplaySymbol = "P";
        public const string QuestDisplaySymbol = "Q";
        public const int BoxWidth = 80;
        public const int BoxHeight = 40;
        public const int PlayerStartingX = 5;
        public const int PlayerStartingY = 5;
        public const ConsoleColor BoxColor = ConsoleColor.DarkGray;
        public const ConsoleColor BombColor = ConsoleColor.Red;
        public const ConsoleColor HeroColor = ConsoleColor.Cyan;
        public const int PriestStartingHp = 5;
        public const int WinIndicator = 10000;
    }
}
