using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Top-level object for a single quest line
    /// </summary>
    public class Quest : ParentQuestStructureElement<Act>
    {
        [SerializeField] private bool _logProgress;


        protected override void Awake()
        {
            base.Awake();
            Debug.Log($"Quest {name} starting up!");
        }

        private void Update()
        {
            if (_logProgress)
            {
                Debug.Log($"{name} progress: {GetProgress()}");
            }
        }

        public Act CurrentAct => CurrentChild;

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

        public bool CheckProgress(string predicate)
        {
            return Parser.IsValid(predicate, GetProgress());
        }

        // Progress: 1.4.7
        // DialogueRule: $x, >1.4.5
        public string GetProgress()
        {
            return $"{CurrentAct.ID}.{CurrentAct.CurrentChapter.ID}.{CurrentAct.CurrentChapter.CurrentTask.ID}";
        }
    }
}
