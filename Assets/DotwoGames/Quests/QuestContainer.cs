using DotwoGames.Common;
using DotwoGames.Common.SerializableDictionary;
using DotwoGames.Quests;
using Quests;
using UnityEngine;

namespace DotwoGames.JRPG.Quests
{
    public class QuestContainer : MonoSingleton<QuestContainer>
    {
        [SerializeField] private SerializableDictionary<QuestID, Quest> quests;

        public Quest Get(QuestID id)
        {
            return quests[id];
        }
    }
}
