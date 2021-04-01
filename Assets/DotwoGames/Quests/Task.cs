using System.Collections.Generic;
using System.Linq;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Singular story element as part of a quest
    /// <para>
    /// Wrapper around Step[] in order to allow a flexible format (e.g. two steps in either order)
    /// </para>
    /// </summary>
    // [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/4. Task")]
    public class Task : BaseQuestStructureElement<Step>
    {
        public List<Step> Steps => Children;

        public List<Step> RemainingSteps => Steps.Where(step => !step.Completed).ToList();
    }
}
