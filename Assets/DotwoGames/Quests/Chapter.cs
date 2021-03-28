using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Small component of a quest, with several steps
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/3. Chapter")]
    public class Chapter : BaseQuestStructureElement<Task>
    {
        public Task CurrentTask => CurrentChild;

        protected override void OnEnable()
        {
            base.OnEnable();
            Children = _children;
        }
    }
}
