using DotwoGames.Common;
using DotwoGames.Common.SerializableDictionary;
using DotwoGames.Quests;
using UnityEngine;

namespace DotwoGames.JRPG.Quests
{
    public class QuestContainer : MonoSingleton<QuestContainer>
    {
        [SerializeField] private SerializableDictionary<string, Quest> quests;

        public Quest Get(string questName)
        {
            return quests[questName];
        }
    }
}
