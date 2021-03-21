using System.Collections.Generic;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Small component of a quest, with several steps
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/3. Chapter")]
    public class Chapter : ScriptableObject
    {
        public int ID;

        public Act parent;

        public Task CurrentTask => tasks[_currentTaskId - 1];

        [SerializeField] private int _currentTaskId;

        [SerializeField] private List<Task> tasks;

        private void OnEnable()
        {
            foreach (Task task in tasks)
            {
                task.parent = this;
            }
        }

        public void NotifyComplete()
        {
            // TODO: Bounds checking
            // If current task was the last task:
            if (_currentTaskId == tasks.Count)
            {
                Debug.Log($"Chaper {ID} is complete!");
                return;
            }

            _currentTaskId++;
        }
    }
}
