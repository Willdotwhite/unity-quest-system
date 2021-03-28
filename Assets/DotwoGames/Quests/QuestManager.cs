using System;
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
        }

        private void Start()
        {
            InvokeRepeating("OnQuestStateChange", 1f, 1f);
        }

        // TODO: Event-ise
        private void OnQuestStateChange()
        {
            quest.UpdateState();
        }
    }
}
