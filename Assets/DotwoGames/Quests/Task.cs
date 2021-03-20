using System.Collections.Generic;
using UnityEngine;

namespace DotwoGames.Quests
{
    /// <summary>
    /// Singular story element as part of a quest
    /// <para>
    /// Wrapper around Step[] in order to allow a flexible format (e.g. two steps in either order)
    /// </para>
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "Quests/4. Task")]
    public class Task : ScriptableObject
    {
        [SerializeField] private List<Step> steps;

    }
}
