namespace TheGame.Helpers
{
    using System;

    public class Constants
    {
        public const string BombDisplaySymbol = "B";
        public const string BoxDisplaySymbol = "#";
        public const string MagicianDisplaySymbol = "M";
        public const string PriestDisplaySymbol = "P";
        public const string QuestDisplaySymbol = "Q";
        public const string WinAreaDisplaySymbol = "W";
        public const string ContinueMessage = "Press Enter to continue.";
        public const string SecondChanceMessage = "  Masters are generous. You have second chance to guess the number.";
        public const string CorrectMessage = "Correct!";
        public const string SecretOfMasters = "   (Here is one secret. The number maybe is {0} than {1}.)";
        public const string WrongMessage = "Wrong.";
        public const string MasterMessageGuessNumber = "C# Masters have one magic favourite number.\n Guess the magic number. \n  It is between 0 and 9 (of course).";
        public const int BoxWidth = 80;
        public const int BoxHeight = 40;
        public const int PlayerStartingX = 1;
        public const int PlayerStartingY = 1;
        public const ConsoleColor BoxColor = ConsoleColor.DarkGray;
        public const ConsoleColor BombColor = ConsoleColor.Red;
        public const ConsoleColor HeroColor = ConsoleColor.Cyan;
        public const ConsoleColor WinAreaColor = ConsoleColor.Yellow;
        public const ConsoleColor QuestsColor = ConsoleColor.DarkGreen;
        public const int PriestStartingHp = 5;
        public const int MagicianStartingHp = 4;
        public const int WinIndicator = 10000;
    }
}