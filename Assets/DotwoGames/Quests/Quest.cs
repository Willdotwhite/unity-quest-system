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
        [SerializeField] private List<Act> acts;
    }
}
