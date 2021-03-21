using System.Collections.Generic;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Large, cohesive unit of a quest
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/2. Act")]
    public class Act : ScriptableObject
    {
        public int ID;

        public Quest parent;

        public Chapter CurrentChapter => chapters[_currentChapterId - 1];

        [SerializeField] private int _currentChapterId;

        [SerializeField] private List<Chapter> chapters;

        private void OnEnable()
        {
            foreach (Chapter c in chapters)
            {
                c.parent = this;
            }
        }
    }
}
