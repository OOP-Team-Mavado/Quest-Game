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
            Position initPosition = new Position(widthCoo, debthCoo);
            List<Position> initPositions = new List<Position>();
            initPositions.Add(initPosition);

            if (questName == "QuizQuest")
            {
                QuizQuest quest = new QuizQuest(initPositions);
                quest.SetID(id);
                return quest;
            }
            else if (questName == "FallingRocks")
            {
                FallingRocks quest = new FallingRocks(initPositions);
                quest.SetID(id);
                return quest;
            }

            return null;
        }
    }
}