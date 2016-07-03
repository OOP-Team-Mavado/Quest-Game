namespace TheGame.Factories
{
    using System;
    using System.Collections.Generic;

    using TheGame.BoardInterfaces;
    using TheGame.Utils;
    using TheGame.BoardPieces.Quests;
    public class QuestFactory
    {
        public static IDisplayPiece getQuest(string questName,int id, int widthCoo, int debthCoo)
        {
            Position initPosition = new Position(widthCoo, debthCoo);
            List<Position> initPositions = new List<Position>();
            initPositions.Add(initPosition);

 

            if(questName == "QuizQuest")
            {
                QuizQuest quest = new QuizQuest(initPositions);
                quest.SetID(id);
                return quest;
            }


            return null;
        }
    }
}
