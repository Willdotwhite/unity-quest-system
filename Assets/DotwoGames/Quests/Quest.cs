using System.Collections.Generic;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Top-level object for a single quest line
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/1. Quest")]
    public class Quest : ScriptableObject
    {
        public int ID;

        public Act CurrentAct => acts[_currentActId - 1];

        [SerializeField] private int _currentActId;

        [SerializeField] private List<Act> acts;

        private void OnEnable()
        {
            foreach (Act c in acts)
            {
                c.parent = this;
            }

            Debug.Log("OnEnable firing!");
        }

        // Progress: 1.4.7
        // DialogueRule: $x, >1.4.5
        public string GetProgress()
        {
            return $"{ID}.{CurrentAct.ID}.{CurrentAct.CurrentChapter.ID}.{CurrentAct.CurrentChapter.CurrentTask.ID}";
        }
    }
}
