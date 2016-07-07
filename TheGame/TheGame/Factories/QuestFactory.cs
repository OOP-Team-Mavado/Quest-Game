namespace TheGame.Factories
{
    using System.Collections.Generic;
    using TheGame.BoardInterfaces;
    using TheGame.BoardPieces.Quests;
    using TheGame.Utils;

    public class QuestFactory
    {
        public static IDisplayPiece GetQuest(string questName, int id, int widthCoo, int debthCoo)
        {
            //// TODO: make the quests drop items
            //// TODO: make items that show on the side of the board (3 items are more than enough)

            Position initPosition = new Position(widthCoo, debthCoo);

            if (questName == "QuizQuest")
            {
                QuizQuest quest = new QuizQuest(initPosition);
                quest.Id = id;
                return quest;
            }
            else if (questName == "FallingRocks")
            {
                FallingRocks quest = new FallingRocks(initPosition);
                quest.Id = id;
                return quest;
            }
            else if (questName == "GuessTheNumber")
            {
                GuessTheNumber quest = new GuessTheNumber(initPosition);
                quest.Id = id;
                return quest;
            }

            return null;
        }
    }
}