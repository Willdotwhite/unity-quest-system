using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Large, cohesive unit of a quest
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/2. Act")]
    public class Act : BaseQuestStructureElement<Chapter>
    {
        public Chapter CurrentChapter => CurrentChild;

        protected override void OnEnable()
        {
            base.OnEnable();
            Children = _children;
        }
    }
}
