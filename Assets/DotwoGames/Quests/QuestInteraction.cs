using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// DEBUG!
    /// </summary>
    public class QuestInteraction : MonoBehaviour
    {
        [SerializeField] private Quest currentQuest;

        private void Awake()
        {
            currentQuest.SetState("1.1.1.1");
        }

        private void Update()
        {
            Debug.Log(currentQuest.GetProgress());

            if (Time.timeSinceLevelLoad > 4f)
            {
                currentQuest.CurrentAct.CurrentChapter.CurrentTask.Debug_CompleteStep(0);
            }

            if (Time.timeSinceLevelLoad > 8f)
            {
                currentQuest.CurrentAct.CurrentChapter.CurrentTask.Debug_CompleteStep(1);
            }
        }
    }
}
