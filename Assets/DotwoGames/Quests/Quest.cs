using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Top-level object for a single quest line
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/1. Quest")]
    public class Quest : BaseQuestStructureElement<Act>
    {
        public Act CurrentAct => CurrentChild;

        protected override void OnEnable()
        {
            base.OnEnable();
            Children = _children;
        }

        /// <summary>
        /// Set the current state of the quest equal to a quest progress string
        /// <para>
        /// e.g. "1.4.2" maps to Act 1, Chapter 4, Task 2
        /// </para>
        /// </summary>
        /// <param name="state"></param>
        public void SetState(string state)
        {
            int actId = int.Parse(state[0].ToString());
            int chapterId = int.Parse(state[2].ToString());
            int taskID = int.Parse(state[4].ToString());

            int[] states = {actId, chapterId, taskID};
            SetState(states);
        }

        // Progress: 1.4.7
        // DialogueRule: $x, >1.4.5
        public string GetProgress()
        {
            return $"{name}: {CurrentAct.ID}.{CurrentAct.CurrentChapter.ID}.{CurrentAct.CurrentChapter.CurrentTask.ID}";
        }
    }
}
