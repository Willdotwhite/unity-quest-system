using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// DEBUG!
    /// </summary>
    public class QuestInteraction : MonoBehaviour
    {
        private Quest currentQuest;

        private void Awake()
        {
            currentQuest = FindObjectOfType<QuestManager>().Quest;

            currentQuest.SetState("1.1.1.1");
        }

        private void Update()
        {
            Debug.Log(currentQuest.GetProgress());

            if (Time.timeSinceLevelLoad > 1.5f)
            {
                currentQuest.CurrentAct.CurrentChapter.CurrentTask.Debug_Complete(0);
            }

            if (Time.timeSinceLevelLoad > 3f)
            {
                currentQuest.CurrentAct.CurrentChapter.CurrentTask.Debug_Complete(1);
            }
        }
    }
}
