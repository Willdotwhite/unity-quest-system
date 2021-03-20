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
        [SerializeField] private List<Chapter> chapters;
    }
}
