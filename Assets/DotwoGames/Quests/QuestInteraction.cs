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

        private bool fired;

        private void Update()
        {
            Debug.Log(currentQuest.GetProgress());

            if (Time.timeSinceLevelLoad > 1f && !fired)
            {
                fired = true;
                currentQuest.CurrentAct.CurrentChapter.CurrentTask.Steps[0].Debug_Complete();
            }
        }
    }
}
