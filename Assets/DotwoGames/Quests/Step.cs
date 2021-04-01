using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Individual element to complete a quest
    /// </summary>
    // [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/5. Step")]
    public /*abstract*/ class Step : MonoBehaviour, IQuestStructureElement
    {
        private bool _completed;

        public event IQuestStructureElement.OnComplete onComplete;

        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                if (_completed)
                {
                    onComplete?.Invoke();
                }
            }
        }

        public void SetState(int[] state)
        {
            Debug.Log($"Not sure what this'll be: {state}, {state.Length}");
        }
    }
}
