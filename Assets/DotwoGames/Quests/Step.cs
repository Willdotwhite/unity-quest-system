using System;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Individual element to complete a quest
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/5. Step")]
    public /*abstract*/ class Step : ScriptableObject
    {
        public int ID;

        public bool Completed { get; private set; }

        public Task parent;

        public void Debug_Complete()
        {
            OnComplete();
        }

        private void OnComplete()
        {
            Completed = true;
            parent.NotifyComplete();
        }
    }
}
