using UnityEngine;

namespace DotwoGames.Quests
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private Quest quest;

        public Quest Quest => quest;

        private void Awake()
        {
            quest = Instantiate(quest);
            quest.SetState("1.1.1");
        }
    }
}
